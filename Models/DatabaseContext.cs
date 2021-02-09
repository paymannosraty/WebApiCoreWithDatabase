using Models.Tools;
using Microsoft.EntityFrameworkCore;

namespace Models
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Models.User> Users { get; set; }

		protected override void OnModelCreating
			(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			#region Model: User
			modelBuilder.Entity<Models.User>()
				.HasIndex(user => new { user.Username })
				.IsUnique(unique: true)
				;

			modelBuilder.Entity<Models.User>()
				.HasData(Seed.FillUser())
				;
			#endregion /Model: User
		}
	}
}
