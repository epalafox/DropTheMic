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
    public class CommentController : BaseController
    {
		/// <summary>
		/// Post new Comment
		/// </summary>
		/// <param name="id"></param>
		/// <param name="comment"></param>
		/// <returns></returns>
		public int Post(int id, [FromBody] CommentModel comment)
		{
			var db = DatabaseHelper.GetDatabase();

			var col = db.GetCollection<PostModel>("post");
			var post = col.FindOne(x => x.Id == id);
			comment.User = User;
			comment.Comments = new List<CommentModel>();
			comment.Id = post.Comments.Count + 1;
			post.Comments.Add(comment);
			col.Update(post);
			return comment.Id;
		}
	}
}
