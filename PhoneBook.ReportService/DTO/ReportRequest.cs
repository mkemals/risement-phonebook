using AutoMapper.Configuration.Annotations;

namespace PhoneBook.ReportService.DTO
{
    public class ReportRequest
    {

        [SourceMember("report_id")]
        public Guid ReportID { get; set; }

        [SourceMember("report_name")]
        public string ReportName { get; set; }

        [SourceMember("generating_status")]
        public byte GeneratingStatus { get; set; } = 1;

        [SourceMember("request_date")]
        public DateTime RequestDate { get; set; }

        public ReportRequest(string repName)
        {
            ReportID = Guid.NewGuid();
            ReportName = repName;
            GeneratingStatus = 1;
            RequestDate = DateTime.Now;
        }
    }
}
