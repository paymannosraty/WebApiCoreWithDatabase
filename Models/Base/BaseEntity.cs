using System;

namespace Models.Base
{
	public class BaseEntity : object
	{
		public BaseEntity() : base()
		{
			Id = Guid.NewGuid();
			InsertDateTime = DateTime.Now;
		}

		public Guid Id { get; set; }

		public DateTime InsertDateTime { get; set; }
	}
}
