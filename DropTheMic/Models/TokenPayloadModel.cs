using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropTheMic.Models
{
	public class TokenPayloadModel
	{
		public int IdUser { get; set; }
		public DateTime LoginDate { get; set; }
	}
}