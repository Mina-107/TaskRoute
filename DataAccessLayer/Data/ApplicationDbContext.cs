

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<IdentityUserLogin<int>>();
            builder.Ignore<IdentityUserToken<int>>();
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);



        }


    }
}
