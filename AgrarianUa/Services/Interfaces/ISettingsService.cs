using AgrarianUa.ViewModels;

namespace AgrarianUa.Services
{
    public interface ISettingsService
    {
        SettingsViewModel Settings(string deviceName, string deviceId, string secret);
        void Update(SettingsViewModel settings, string deviceName, string deviceId, string location);
    }
}