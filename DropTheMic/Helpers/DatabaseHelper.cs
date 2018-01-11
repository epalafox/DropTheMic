using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropTheMic.Helpers
{
	public static class DatabaseHelper
	{
		static LiteDatabase db;
		public static LiteDatabase GetDatabase()
		{
			if (db == null)
				db = new LiteDatabase(HttpContext.Current.Server.MapPath("~/App_Data/mydata.db"));
			return db;
		}
	}
}