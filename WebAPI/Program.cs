using EmployeeManagement.Services;

namespace EmployeeManagement.WebAPI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var dataAccess = builder.Configuration.GetValue("DataAccess", "SqlServerEF");
            if (dataAccess == "SqlServerEF")
                builder.Services.AddTransient<IEmployeeService, Services.EF.EmployeeService>();
            else
            if (dataAccess == "SqlServerDapper")
                builder.Services.AddTransient<IEmployeeService, Services.Dapper.EmployeeService>();
            else
            if (dataAccess == "PostgreSqlDapper")
                builder.Services.AddTransient<IEmployeeService, Services.DapperPG.EmployeeService>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}