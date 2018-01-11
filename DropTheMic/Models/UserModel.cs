using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropTheMic.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public GeneroEnum Gender { get; set; }
		internal DateTime BirthDate { get; set; }
		public string Birthday { get; set; }
	}
}