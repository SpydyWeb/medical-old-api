using CORE.TablesObjects;
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
        //public virtual DbSet<PentaDetail> PentaDetails { get; set; }
         //public virtual DbSet<PentaDetail> PentaDetails { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            //modelBuilder.Entity<PentaDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.ToTable("PentaDetails", "dbo");
            //});

            modelBuilder.UserModelBuilder();
			base.OnModelCreating(modelBuilder);
		}
	}
}
