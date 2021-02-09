using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class User : Base.BaseEntity
	{
		public User() : base()
		{
		}

		public string FullName { get; set; }

		[Required]
		public string Username { get; set; }
	}
}
