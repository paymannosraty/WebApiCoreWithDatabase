namespace Models
{
	public class User : Base.BaseEntity
	{
		public User() : base()
		{
		}

		public string FullName { get; set; }

		public string Username { get; set; }
	}
}
