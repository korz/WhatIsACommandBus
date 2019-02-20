using System.Configuration;

namespace Contracts
{
    public static class Settings
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;
    }
}
