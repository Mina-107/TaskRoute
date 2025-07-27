namespace DataAccessLayer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _storeContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext storeContext,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _storeContext = storeContext;
           _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task InitializeAsync()
        {
            try

            {

          
                if (_storeContext.Database.GetPendingMigrations().Any())
                    await _storeContext.Database.MigrateAsync();
        
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task InitializeIdentityAsync()
        {
           //Seed Default Roles
           if(! _roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                

            }
            //Seed Default Users
            if(! _userManager.Users.Any())
            {
                var SuperAdminUser = new ApplicationUser
                {
                
                    Email= "SuperAdminUser@gmail.com",
                    UserName= "SuperAdminUser",
                    PhoneNumber="01225770196"

                };
                var AdminUser = new ApplicationUser
                {
                 
                    Email= "AdminUser@gmail.com",
                    UserName= "AdminUser",
                    PhoneNumber="01225770187"

                };
                await _userManager.CreateAsync(SuperAdminUser, "Passw0rd");//Password
                await _userManager.CreateAsync(AdminUser, "Passw0rd");
                //-------------------------------------------------------
                await _userManager.AddToRoleAsync(SuperAdminUser, "SuperAdmin");
                await _userManager.AddToRoleAsync(AdminUser, "Admin");


            }
        }
    }
}
