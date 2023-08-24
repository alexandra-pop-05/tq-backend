
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TQ_Project.Application.Interfaces;
using TQ_Project.Application.MappingProfiles;
using TQ_Project.Application.Services;
using TQ_Project.Domain.DataAccess;
using TQ_Project.Domain.Interfaces;
using TQ_Project.Domain.Repositories;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Mapping)));
            builder.Services.AddAuthorization(opt =>
            {
               // opt.AddPolicy("NamePolicy", pol => pol.RequireClaim("Name", "Ioana", "Eliodor", "Veaceslav"));

                opt.AddPolicy("AdminOrUser", pol => pol.RequireRole("Admin", "User"));
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //services
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IUser, UserRepository>();
            builder.Services.AddTransient<IEventService, EventService>();
            builder.Services.AddTransient<IEvent, EventRepository>();
            builder.Services.AddTransient<IProjectService, ProjectService>();
            builder.Services.AddTransient<IProject, ProjectRepository>();
            //db context
            builder.Services.AddDbContext<EfCoreDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();


           /* app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization();

                endpoints.MapSwagger();
            });*/

            app.Run();
        }
    }
}