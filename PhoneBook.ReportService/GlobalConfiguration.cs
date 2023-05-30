namespace PhoneBook.ReportService
{

    public static class GlobalConfiguration
    {
        private static IConfiguration Configuration = null;

        public static ConfigConnectionStrings ConnectionStrings { get; set; }
        public static ConfigAppSettings AppSettings { get; set; }

        public static void Build()
        {
            if (Configuration == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                Configuration = builder.Build();
                if (Configuration == null)
                {
                    //TODO: Log
                }
                ConnectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConfigConnectionStrings>();
                AppSettings = Configuration.GetSection("AppSettings").Get<ConfigAppSettings>();
            }
        }

    }

    public class ConfigConnectionStrings
    {
        public string _PhoneBook { get; set; } = "";
        public string PhoneBook { get; set; } = "";
    }
    public class ConfigAppSettings
    {
    }

}

