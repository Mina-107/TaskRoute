


namespace BusinessLogicLayer.SI.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
        
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(o => o.ProductId, d => d.MapFrom(s => s.Product.ProductId))
               
                .ForMember(o => o.ProductName, d => d.MapFrom(s => s.Product.ProductName));
         
            CreateMap<Order, OrderResult>()
              .ForMember(o => o.PaymentStatus, d => d.MapFrom(s => s.ToString()))
              .ForMember(o => o.DeliveryMethod, d => d.MapFrom(s => s.DeliveryMethod.ShortName))
              .ForMember(o => o.Total, d => d.MapFrom(s => s.SubTotal+s.DeliveryMethod.Price));
  
       
            CreateMap<DeliveryMethod, DeliverMethodResult>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap().ForMember(dest => dest.PaymentStatus,
                       opt => opt.MapFrom(src => src.PaymentStatus.ToString())); ;
        
        }

    }
}
