using System;
using System.Collections.Generic;
using System.Linq;
using AgrarianUa.ViewModels;
using AutoMapper;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AgrarianUa.Services
{
    public class LocationService : ILocationService
    {

        private readonly AgrarianDbContextPath.AgrarianDbContext _context;

        public LocationService(AgrarianDbContextPath.AgrarianDbContext context)
        {
            _context = context;
        }

        public List<LocationViewModel> Locations()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceViewModel>();
                cfg.CreateMap<Location, LocationViewModel>();
                cfg.CreateMap<List<Device>, List<DeviceViewModel>>();
                cfg.CreateMap<Settings, SettingsViewModel>();
            });
            var locations = _context.Locations.Include(x => x.Devices).ToList();
            var mapper = new Mapper(config);
            var locationsViewModel = mapper.Map<List<LocationViewModel>>(locations);

            return locationsViewModel;
        }

        public LocationViewModel Location(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Location, LocationViewModel>().ForMember(x => x.Devices, c => c.MapFrom(m => m.Devices));
                cfg.CreateMap<Device, DeviceViewModel>();
                cfg.CreateMap<List<Device>, List<DeviceViewModel>>();
            });
            var location = _context.Locations.Where(x => x.Id == id).Include(x => x.Devices).FirstOrDefault();

            if(location == null) { return null; }

            var mapper = new Mapper(config);
            var locationViewModel = mapper.Map<LocationViewModel>(location);

            return locationViewModel;
        }

        public void Add(string name)
        {
            Location location = new Location() { Name = name };
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void Update(int id, string name)
        {
            var location = _context.Locations.Where(x => x.Id == id).FirstOrDefault();
            if(location == null) { return; }
            location.Name = name;
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var location = _context.Locations.Where(x => x.Id == id).FirstOrDefault();
            if(location == null) { return false; }
            _context.Locations.Remove(location);
            _context.SaveChanges();
            return true;
        }
    }
}
