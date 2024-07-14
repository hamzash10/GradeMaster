
using GradeMasterAPI.Controllers.DB;
using GradeMasterAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace GradeMasterAPI
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

            //Register Global Db Service wiht EF (ententy framework)
            builder.Services.AddDbContext<GradeMasterDbContext>(options =>
                options.UseSqlServer("Data Source=HAMZASH\\SQLEXPRESS;Initial Catalog=GradeMAsterDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));
            

            //TODO add other Services here
            builder.Services.AddSingleton<ICsvLoader,CsvLoader>();


            //this menas any one can access this database using any domain, any api method, any header
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("openapi",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });



            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    //get Regesteder GradeMasterDbContext Service
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<GradeMasterDbContext>();

                    //Initilize Db
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                }
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //open all options in api
            app.UseCors("openapi");


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
