
namespace BusinessLogicLayer.SI.Services
{
    public class CustomerServices(IUnitOfWork unitOfWork,UserManager<ApplicationUser> _userManager, IMapper mapper) : ICustomerServices
    {
        public async Task<IEnumerable<OrderResponse>> GetAllOrdersOfUser(string id) {

   var orders = await unitOfWork.GetRepository<Order, Guid>().GetAllAsync(new OrderWithIncludeSpecifications(id));
            return orders.Select(e=> mapper.Map<OrderResponse>(orders)) ;

        }
        public async Task<bool> CreateCustomerAsync(CustomerRequest customerDto)
        {
      
            if (await _userManager.FindByEmailAsync(customerDto.Email) != null)
            {
                throw new customerAlradyExist(customerDto.Email);
            }

            using var transaction = await unitOfWork.BeginTransactionAsync();
          
                var user = new ApplicationUser
                {
                    UserName = customerDto.Username,
                    Email = customerDto.Email
                };
                var identityResult = await _userManager.CreateAsync(user, customerDto.Password);
                if (!identityResult.Succeeded)
                {
                throw new Exception("not created");
                }
                await _userManager.AddToRoleAsync(user, "Customer");

                var customer = new DataAccessLayer.Data.Entities.Customer
                {
                    Name = customerDto.Name,
                    Email = customerDto.Email,
                    UserId = user.Id 
                };
                unitOfWork.GetRepository<DataAccessLayer.Data.Entities.Customer,string>().Add(customer);
                await unitOfWork.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
    
        
    }
}
