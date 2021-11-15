
namespace AltV.BlipSystem.Server.Structure
{
    public class DatabaseConfig
    {
        public string Type { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Schema { get; set; }
        public int Port { get; set; }

        public DatabaseConfig() { }
    }
}
