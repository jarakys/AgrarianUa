using System.Linq;
using AgrarianUa.ViewModels;
using AutoMapper;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AgrarianUa.Services
{
    public class DeviceService : IDeviceService
    {

        private readonly AgrarianDbContextPath.AgrarianDbContext _context;

        public DeviceService(AgrarianDbContextPath.AgrarianDbContext context)
        {
            _context = context;
        }

        public bool Register(string name, string id, int locationId)
        {
            var location = _context.Locations.Where(x => x.Id == locationId).Include(x=>x.Devices).FirstOrDefault();

            if(location == null) { return false; }

            location.Devices.Add(new Core.Models.Device() { DeviceId = id, Name = name, Settings = new Settings() });
            _context.SaveChanges();

            return true;
        }

        public DeviceViewModel Device(string name, string id, int locationId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceViewModel>();
                cfg.CreateMap<Location, LocationViewModel>();
                cfg.CreateMap<Settings, SettingsViewModel>();
            });

            var device = _context.Devices.Include(x=>x.Location).Where(x => x.DeviceId == id &&
                                                                            x.Name == name &&
                                                                            x.Location.Id == locationId).FirstOrDefault();
            if(device == null) { return null; }

            var mapper = new Mapper(config);
            var deviceViewModel = mapper.Map<DeviceViewModel>(device);

            return deviceViewModel;
        }
    }
}
