namespace APPROVAL
{
    public class AppSettings
    {
        public Logging Logging { get; set; }

        public string AllowdHosts { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
        
        public ElasticApm ElasticApm { get; set; }

    }

    public class Logging
    {
        public LogLevel[] LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        
        //public string Microsoft.Hosting.Lifetime { get; set; }
    }

    public class ConnectionStrings
    {
        public string ApprovalConnection { get; set; }
        public string SqlConnection { get; set; }
        public string MariaConnection { get; set; }
    }

    public class ElasticApm
    {
        public string ServerUrls { get; set; }
        public string ServiceName { get; set; }

        public string ApprovalConnection { get; set; }
        public string Environment { get; set; }
    }


}