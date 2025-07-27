
using BusinessLogicLayer.SI.Common.Services.EmailSettings;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace BusinessLogicLayer.SI
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services) {
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IInvoiceServices, Invoiceservices>();
            services.AddScoped<IEmailSettings, EmailSettings>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}

