



namespace DataAccessLayer
{
    public static class ApplicationDataRegistration
    {
        public static IServiceCollection ApplicationData(this IServiceCollection services,IConfiguration configuration) {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddScoped<IBasketRepository, BasketRepository>();

            services.AddDbContext<ApplicationDbContext>(options=> {
                configuration.GetConnectionString("DefaultConnection");
                //services.AddHttpContextAccessor();
            });
            services.AddSingleton<IConnectionMultiplexer>(
               _ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
            services.ConfigureIdentityService();
            services.AddSingleton<IConnectionMultiplexer>(
                _ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
            return  services;
        }
        public static IServiceCollection ConfigureIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
  .AddRoles<IdentityRole>() 
  .AddEntityFrameworkStores<ApplicationDbContext>();
  

            return services;

        }
      
    }
}
