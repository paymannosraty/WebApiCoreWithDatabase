using System;
using System.Collections.Generic;

namespace Models.Tools
{
	public static class Seed
	{
		static Seed()
		{
		}

		#region User
		public static IEnumerable<Models.User> FillUser()
		{
			List<Models.User> result =
				new List<Models.User>()
				{
					new Models.User(){ FullName = "administrator", Username = "admin" },
				};

			return result;
		}
		#endregion /User
	}
}
