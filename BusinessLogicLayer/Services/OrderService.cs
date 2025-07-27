


using Customer = DataAccessLayer.Data.Entities.Customer;

namespace Services
{
    public class OrderService(IMapper mapper,IUnitOfWork unitOfWork, IBasketRepository basketRepository,IEmailSettings emailSettings) : IOrderService
    {
        public async Task<OrderResult> CreateOrUpdateOrderAsync(OrderRequest request, string userId)
        {
            var Basket = await basketRepository.GetBasketAsync(request.BasketId)
                ?? throw new BasketNotFoundException(request.BasketId);
            var OrderItems = new List<OrderItem>();
             foreach( var item in Basket.Items)
            {
                var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(item.Id);
                   if (product is null  || (item.quantity > product.Stock))  throw new customerAlradyExist($"{item.Id}");
                OrderItems.Add(CreateOrderItem(item, product));
            }
            var OrderRepo = unitOfWork.GetRepository<Order, Guid>();
            var existingOrder = await OrderRepo.GetByIdAsync(new OrderWithPaymentIntentIdSpecifications(Basket.PaymentIntentId));
             if (existingOrder is not null)
            {
                OrderRepo.Delete(existingOrder);
            }
           
            var DeliveyMethod = await unitOfWork.GetRepository<DeliveryMethod, int>()
               .GetByIdAsync(request.DeliveryMethodId)
               ?? throw new DeliveyMethodNotFoundException(request.DeliveryMethodId);
            var SubTotal = OrderItems.Sum(item => item.Price * item.Quantity);

            const decimal DiscountIncrementAmount = 100m; 
            const decimal DiscountRatePerIncrement = 0.05m; 
            const decimal MaxDiscountRate = 0.25m; 


            var numberOfIncrements = Math.Floor(SubTotal / DiscountIncrementAmount);

            var calculatedDiscountRate = (decimal)numberOfIncrements * DiscountRatePerIncrement;

            var finalDiscountRate = Math.Min(calculatedDiscountRate, MaxDiscountRate);

            var subTotalAfterDiscount = SubTotal * (1 - finalDiscountRate);


           
            var order = new Order(userId, OrderItems, DeliveyMethod, subTotalAfterDiscount, Basket.PaymentIntentId);
             OrderRepo.Add(order);
            var newInvoice = new DataAccessLayer.Data.Entities.Invoice
            {
                Order = order,
                InvoiceDate = DateTime.Now,
                TotalAmount = order.SubTotal+ DeliveyMethod.Price
            };

            unitOfWork.GetRepository<DataAccessLayer.Data.Entities.Invoice, int>().Add(newInvoice);

            await unitOfWork.SaveChangesAsync();
           
            return mapper.Map<OrderResult>(order);







        }

        private OrderItem CreateOrderItem(BasketItem item, Product Product)
        => new OrderItem(new ProductInOrderItem(Product.Id, Product.Name),
            item.quantity, Product.Price,item.Discount);

        public async Task<IEnumerable<DeliverMethodResult>> GetDeliveryMethodsAsync()
        {
            var Methods = await unitOfWork.GetRepository<DeliveryMethod, int>()
                   .GetAllAsync();
            return mapper.Map<IEnumerable<DeliverMethodResult>>(Methods);
        }

        public async Task<IEnumerable<OrderResponse>> GetAllAsync()
        {

            var orders = await unitOfWork.GetRepository<Order, Guid>().GetAllAsync(new OrderWithIncludeSpecifications());
            return orders.Select(e => mapper.Map<OrderResponse>(orders));
        }


        public async Task<OrderResult> GetOrderByIdAsync(Guid id)
        {
            var Order = await unitOfWork.GetRepository<Order, Guid>()
                .GetByIdAsync(new OrderWithIncludeSpecifications(id))
                ?? throw new OrderNotFoundException(id);
            return mapper.Map<OrderResult>(Order);
        }

        public async Task<int> UpdateOrderStatusAsync(Guid id, StatusOrder status)
        {
          var order= await  unitOfWork.GetRepository<Order, Guid>().GetByIdAsync(id);
            if (order == null)
                throw new OrderNotFoundException(id);
         var customer=  await unitOfWork.GetRepository<Customer, string>().GetByIdAsync(order.CustomerId);
            var email = new Email() { Subject= " Change status order",
            Body = $"the order has id = {order.Id} the status changed from {order.StatusOrder} to{status}",
            To=customer.Email
            };
            emailSettings.SendEmail(email);
            order.StatusOrder=status;
            return await unitOfWork.SaveChangesAsync();
        }
    }
}

