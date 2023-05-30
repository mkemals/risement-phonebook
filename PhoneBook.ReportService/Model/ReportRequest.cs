using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.ReportService.Model
{

    [Table("report_request")]
    public class ReportRequest
    {

        // report_id uuid NOT NULL DEFAULT gen_random_uuid(),
        public Guid report_id { get; set; }
        // report_name varchar NOT NULL,
        public string report_name { get; set; }
        // generating_status int2 NULL DEFAULT 1,
        public byte generating_status { get; set; } = 1;
        // request_date timestamp NULL DEFAULT CURRENT_TIMESTAMP,
        public DateTime request_date { get; set; }

        public ReportRequest(string repName)
        {
            report_id = Guid.NewGuid();
            report_name = repName;
            generating_status = 1;
            request_date = DateTime.Now;
        }

    }
}
