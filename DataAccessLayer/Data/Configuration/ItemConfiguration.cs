

namespace DataAccessLayer.Data.Configuration
{
    internal class ItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");
            builder.OwnsOne(item => item.Product, product => product.WithOwner());

        }


    }
}

