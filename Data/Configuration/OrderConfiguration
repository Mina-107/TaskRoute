

namespace DataAccessLayer.Data.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(e=>e.OrderItems).WithOne().HasForeignKey();
            builder.HasOne(e=>e.Customer).WithMany(e=>e.Orders).HasForeignKey(e=>e.CustomerId);
   
        }
    }
}

