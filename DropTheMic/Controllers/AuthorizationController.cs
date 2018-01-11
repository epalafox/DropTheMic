using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DropTheMic.Models;
using LiteDB;
using System.Web;
using DropTheMic.Helpers;

namespace DropTheMic.Controllers
{
    public class AuthorizationController : BaseController
    {
		public IHttpActionResult Get(string UserName, string Password)
		{
			Dictionary<string, string> token = new Dictionary<string, string>();
			var db = DatabaseHelper.GetDatabase();
			
			var col = db.GetCollection<UserModel>("users");
			var result = col.Find(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
			if (result != null && result.Id != 0)
			{
				TokenPayloadModel payload = new TokenPayloadModel()
				{
					IdUser = result.Id,
					LoginDate = DateTime.Now
				};
				byte[] key = Base64Helper.Base64UrlDecode("DropTheMic");
				token.Add("WebToken", Jose.JWT.Encode(payload, key, Jose.JwsAlgorithm.HS256));
				token.Add("IdUser", payload.IdUser.ToString());
			}
			else
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return Ok(token);
		}
	}
}
