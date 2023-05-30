using Microsoft.EntityFrameworkCore;

namespace PhoneBook.ReportService
{
    public class ReportContext: DbContext
    {
        public ReportContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Model.ReportRequest> ReportRequests { get; set; }

    }
}
