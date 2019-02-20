using System.Configuration;

namespace Cqrs
{
    public static class Settings
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;
    }
}
