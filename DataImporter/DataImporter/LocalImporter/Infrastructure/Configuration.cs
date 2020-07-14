namespace LocalImporter.Infrastructure
{
    public class Configuration
    {
        public ConnectionStringConfig ConnectionStrings { get; set; }

        public class ConnectionStringConfig
        {
            public string DbConnection { get; set; }
        }
    }
}