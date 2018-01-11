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
    public class UsersController : BaseController
    {
		/// <summary>
		/// Get all users
		/// </summary>
		/// <returns></returns>
        // GET: api/Users
        public IEnumerable<UserModel> Get()
		{
			IEnumerable<UserModel> users;
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<UserModel>("users");
			users = col.FindAll();
			return users;
		}
		/// <summary>
		/// Get user by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        // GET: api/Users/5
        public UserModel Get(int id)
        {
			UserModel user;
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<UserModel>("users");
			user = col.FindOne(x => x.Id == id);
			return user;
        }
		/// <summary>
		/// Get users by username
		/// </summary>
		/// <param name="term"></param>
		/// <returns></returns>
		//GET api/Users?term=[string]
		public IEnumerable<UserModel> Get(string term)
		{
			IEnumerable<UserModel> users;
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<UserModel>("users");
			users = col.Find(x => x.UserName == term);
			return users;
		}
		/// <summary>
		/// Creates new user
		/// </summary>
		/// <param name="newUser"></param>
		/// <returns></returns>
        // POST: api/Users
        public IHttpActionResult Post([FromBody]UserModel newUser)
		{
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<UserModel>("users");
			col.Insert(newUser);
			return Ok();
		}

		/// <summary>
		/// Updates user
		/// </summary>
		/// <param name="editUser"></param>
		/// <returns></returns>
		// PUT: api/Users/5
		public IHttpActionResult Put([FromBody]UserModel editUser)
        {
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<UserModel>("users");
			var user = col.FindOne(x => User.Id == x.Id);
			user.Birthday = editUser.Birthday;
			user.Gender = editUser.Gender;
			user.Password = editUser.Password;
			user.UserName = editUser.UserName;
			col.Update(user);
			return Ok();
		}
    }
}
