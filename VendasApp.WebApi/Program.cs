using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using VendaApp.Infra.IoC;
using VendasApp.Infra.Data;

namespace VendasApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                }
               );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<VendasAppContext>();

            DependencyInjection.AddInfrastructure(builder.Services, builder.Configuration);

            // Add JWT Authentication Middleware - This code will intercept HTTP request and validate the JWT.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
              );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

            //app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
                {
                    await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
                }
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}