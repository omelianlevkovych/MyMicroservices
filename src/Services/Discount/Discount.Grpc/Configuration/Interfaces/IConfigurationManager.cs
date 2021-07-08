namespace Discount.Grpc.Configuration.Interfaces
{
    public interface IConfigurationManager
    {
        T GetConfiguration<T>(string key);

        T GetConfigurationOrDefault<T>(string key, T defaultValue);
    }
}
