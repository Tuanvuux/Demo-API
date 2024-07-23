using BLL.Services;
using BLL.Services.IServices;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo_API
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            builder.Services.AddDbContext<APIDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"), options =>
                    options.MigrationsAssembly("GUI"));
            });

            // Repositories
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
            builder.Services.AddScoped<IIndividualRepository, IndividualRepository>();
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccTransactionRepository, AccTransactionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Services
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IBusinessService, BusinessService>();
            builder.Services.AddScoped<IIndividualService, IndividualService>();
            builder.Services.AddScoped<IBranchService, BranchService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAccTransactionService, AccTransactionService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
