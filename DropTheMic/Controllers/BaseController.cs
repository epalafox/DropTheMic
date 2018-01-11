using DropTheMic.Helpers;
using DropTheMic.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DropTheMic.Controllers
{
    public class BaseController : ApiController
    {
		public UserModel User;
		/// <summary>
		/// Get user from token
		/// </summary>
		/// <param name="user"></param>
		internal void InstanceUser(TokenPayloadModel user)
		{
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<UserModel>("users");
			User = col.FindOne(x => x.Id == user.IdUser);
		}
    }
}
