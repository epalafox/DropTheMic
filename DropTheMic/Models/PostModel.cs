using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropTheMic.Models
{
	public class PostModel
	{
		public int Id { get; set; }
		public string Post { get; set; }
		internal DateTime DateHour { get; set; }
		public string Date { get; set;}
		public string Hour { get; set; }
		public UserModel User { get; set; }
		public List<CommentModel> Comments { get; set; }
	}
}