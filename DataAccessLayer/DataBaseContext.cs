using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
	public class DataBaseContext : IdentityDbContext
	{
		public DataBaseContext(DbContextOptions option)
			: base(option)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.UserModelBuilder();
			base.OnModelCreating(modelBuilder);
		}
	}
}
