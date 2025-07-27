
namespace DataAccessLayer.Data.Configuration
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10,3)");
            builder.HasOne(e => e.Order).WithMany().HasForeignKey(e => e.OrderId);
        }
    }
}

