namespace PhoneBook.ReportService.Model
{
    public class QueueRequest
    {
        public string ReportMethod { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// Kuyruğa alınacak raporu tanımlamak için kullanılıyor
        /// </summary>
        public QueueRequest()
        {
            ReportMethod = "";
            Parameters = new Dictionary<string, string>();
        }
    }

}
