using Microsoft.EntityFrameworkCore;

namespace PhoneBook.PersonService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEntityFrameworkNpgsql()
                            .AddDbContext<PersonContext>(o => o.UseNpgsql(GlobalConfiguration.ConnectionStrings.PhoneBook));

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}