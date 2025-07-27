namespace DataAccessLayer.Data.Entities
{
    public class Invoice:BaseEntity<int>
    {

        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
       
    }
}

 
