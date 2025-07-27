
namespace DataAccessLayer.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
     .HasOne(u => u.customer)    
     .WithOne(c => c.User)       
     .HasForeignKey<Customer>(c => c.UserId);
        }
    }
}

