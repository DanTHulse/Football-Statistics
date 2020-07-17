namespace FutbolApi
{
    public class AppSettings
    {
        public ConnectionStringConfig ConnectionStrings { get; set; }

        public class ConnectionStringConfig
        {
            public string DbConnection { get; set; }
        }
    }
}
