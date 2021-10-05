namespace CariocaMix.CrossCutting.Interfaces
{
    public interface IConfigurationHelper
    {
        string GetString(string key);

        T GetValue<T>(string key);
    }
}
