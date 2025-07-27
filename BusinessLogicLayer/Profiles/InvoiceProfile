namespace BusinessLogicLayer.SI.Profiles
{
    public static class InvoiceProfile
    {
        public static InvoiceResponse ToRespose(this DataAccessLayer.Data.Entities.Invoice invoice)
        {

            return new InvoiceResponse()
            {
                Id = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                OrderId = invoice.OrderId,
                TotalAmount = invoice.TotalAmount

            };


        }
        public static InvoiceResponseDetails ToResposeDetails(this DataAccessLayer.Data.Entities.Invoice invoice)
        {

            return new()
            {
                Id = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                OrderId = invoice.OrderId,
                TotalAmount = invoice.TotalAmount,
                OrderDate = invoice.Order.OrderDate,
                PaymentMethod = invoice.Order.PaymentStatus.ToString(),
                Status = invoice.Order.StatusOrder.ToString()


            };

        }
    }
}
