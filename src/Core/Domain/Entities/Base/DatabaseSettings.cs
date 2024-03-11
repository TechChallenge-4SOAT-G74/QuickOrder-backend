namespace QuickOrder.Core.Domain.Entities.Base
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string SecretManagerKey { get; set; }
    }

    public class DatabaseMongoDBSettings : DatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;

    }
}
