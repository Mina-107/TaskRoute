
using AutoMapper;

using BusinessLogicLayer.SI.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace TaskRoute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
       
            builder.Services.AddHttpContextAccessor();
            var jwtoptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtoptions.Issuer,
                    ValidAudience = jwtoptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey))
                };



            });
            builder.Services.AddAuthorization();
            builder.Services.ApplicationServices();


            builder.Services.ApplicationData(builder.Configuration);

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new BasketProfile());
                cfg.AddProfile(new OrderProfile());
            });
            var app = builder.Build();



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
