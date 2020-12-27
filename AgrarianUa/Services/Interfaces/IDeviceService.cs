using AgrarianUa.ViewModels;

namespace AgrarianUa.Services
{
    public interface IDeviceService
    {
        DeviceViewModel Device(string name, string id, int locationId);
        bool Register(string name, string id, int locationId);
    }
}