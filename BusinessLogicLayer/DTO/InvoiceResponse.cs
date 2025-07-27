namespace BusinessLogicLayer.SI.DTO
{
    public class InvoiceResponse
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}

