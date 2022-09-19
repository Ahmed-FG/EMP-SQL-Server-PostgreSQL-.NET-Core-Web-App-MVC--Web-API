using EmployeeManagement.Services;
using EmployeeManagement.Models;

namespace EmployeeManagement.WebApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            var dataAccess = builder.Configuration.GetValue<string>("Services", "SqlServerEF");
            if (dataAccess == "SqlServerEF")
                builder.Services.AddTransient<IEmployeeService, Services.EF.EmployeeService>();
            else
            if (dataAccess == "SqlServerDapper")
                builder.Services.AddTransient<IEmployeeService, Services.Dapper.EmployeeService>();
            else
            if (dataAccess == "PostgreSqlDapper")
                builder.Services.AddTransient<IEmployeeService, Services.DapperPG.EmployeeService>();
            else
            if (dataAccess == "WebAPI")
                builder.Services.AddTransient<IEmployeeService, Services.WebAPI.EmployeeService>();

            //builder.Services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(
            //    builder.Configuration.GetConnectionString("DefaultConnection")
            //    ));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}