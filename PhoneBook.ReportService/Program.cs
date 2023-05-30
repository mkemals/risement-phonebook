using Microsoft.EntityFrameworkCore;

namespace PhoneBook.ReportService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Config değerleri uygulama başlangıcında çekiliyor.
            GlobalConfiguration.Build();

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // add EF
            builder.Services.AddEntityFrameworkNpgsql()
                            .AddDbContext<ReportContext>(o => o.UseNpgsql(GlobalConfiguration.ConnectionStrings.PhoneBook));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}