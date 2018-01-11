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
    public class PostController : BaseController
    {
		/// <summary>
		/// Get all posts
		/// </summary>
		/// <returns></returns>
		public IEnumerable<PostModel> Get()
		{
			IEnumerable<PostModel> posts;
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<PostModel>("post");
			posts = col.FindAll();
			return posts;
		}
		/// <summary>
		/// Get Post by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PostModel Get(int id)
		{
			PostModel post;
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<PostModel>("post");
			post = col.FindOne(x => x.Id == id);
			return post;
		}
		/// <summary>
		/// Creates new Post
		/// </summary>
		/// <param name="post"></param>
		/// <returns></returns>
		public int Post([FromBody] PostModel post)
		{
			int id;
			var db = DatabaseHelper.GetDatabase();
			var col = db.GetCollection<PostModel>("post");
			post.User = User;
			if(post.Date == null && post.Hour == null)
			{
				post.DateHour = DateTime.Now;
				post.Date = post.DateHour.ToString("dd/MM/yyyy");
				post.Hour = post.DateHour.ToString("HH:mm");
			}
			post.Comments = new List<CommentModel>();
			col.Insert(post);
			id = post.Id;
			return id;
		}
    }
}
