namespace Infrastructure
{
	public class BaseApiControllerWithDatabase : BaseApiController
	{
		public BaseApiControllerWithDatabase(Models.DatabaseContext databaseContext) : base()
		{
			DatabaseContext = databaseContext;
		}

		protected Models.DatabaseContext DatabaseContext { get; }
	}
}
