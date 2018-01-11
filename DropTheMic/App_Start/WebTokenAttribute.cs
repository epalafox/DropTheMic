using DropTheMic.Controllers;
using DropTheMic.Helpers;
using DropTheMic.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;
using System.Net;
using System.Web.Http.Controllers;

namespace DropTheMic.App_Start
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class WebTokenAttribute : System.Web.Http.Filters.ActionFilterAttribute, IFilter
	{
		private BaseController controller;

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			string token;
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			controller = actionContext.ControllerContext.Controller as BaseController;

			if (actionContext.ControllerContext.Request.Headers.Authorization != null)
			{
				try
				{
					token = actionContext.ControllerContext.Request.Headers.Authorization.ToString();
					byte[] key = Base64Helper.Base64UrlDecode("DropTheMic");
					JObject userJSON = JObject.Parse(Jose.JWT.Decode(token, key, Jose.JwsAlgorithm.HS256));

					TokenPayloadModel user = serializer.Deserialize<TokenPayloadModel>(userJSON.ToString());
					controller.InstanceUser(user);
				}
				catch (Exception ex)
				{
					throw new HttpResponseException(HttpStatusCode.Unauthorized);
				}
			}
			else
			{
				if (!((controller is AuthorizationController) || (controller is UsersController && actionContext.Request.Method == System.Net.Http.HttpMethod.Post)))
				{
					throw new HttpResponseException(HttpStatusCode.Unauthorized);
				}
			}
			base.OnActionExecuting(actionContext);
		}
	}
}