using QuickOrder.Core.Domain.Entities.Base;

namespace QuickOrder.Core.IoC
{
    public class AppSettings : BaseSettings
    {
        private string _connectionString;
        public string AwsCredentialProfile { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString) && Database?.SecretManagerKey != null)
                {
                    _connectionString = AwsSecretGetter.GetSecret(Database.SecretManagerKey, Region, AwsCredentialProfile);
                }
                return _connectionString;
            }
        }
    }

    public class BaseSettings : Settings
    {
        public DatabaseSettings Database { get; set; }
    }

    public class Settings : ISettings
    {
        public string Stage { get; set; }
        public string Region { get; set; }
    }
    public interface ISettings
    {
        public string Stage { get; set; }
        public string Region { get; set; }
    }



}
