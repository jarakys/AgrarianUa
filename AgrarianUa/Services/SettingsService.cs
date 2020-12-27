using System;
using System.Collections.Generic;
using System.Linq;
using AgrarianUa.ViewModels;
using AutoMapper;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AgrarianUa.Services
{
    public class SettingsService : ISettingsService
    {

        private readonly AgrarianDbContextPath.AgrarianDbContext _context;

        public SettingsService(AgrarianDbContextPath.AgrarianDbContext context)
        {
            _context = context;
        }

        public void Update(SettingsViewModel settings, string deviceName, string deviceId, string location)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<ScheduleViewModel>, List<Schedule>>();
            });

            var _settings = _context.Settings.Include(x => x.Device).
                                              Include(x => x.Device.Location).
                                              Where(x => x.Device.DeviceId == deviceId &&
                                              x.Device.Location.Name == location).FirstOrDefault();

            if(_settings == null) { return; }

            var mapper = new Mapper(config);
            _settings.AirHumidity = settings.AirHumidity;
            _settings.AutoLighting = settings.AutoLighting;
            _settings.Autowatering = settings.Autowatering;
            _settings.LightingSchedules = mapper.Map<List<Schedule>>(settings.LightingSchedules);
            _settings.SoilTemperature = settings.SoilTemperature;
            _settings.Temperature = settings.Temperature;
            _settings.WateringSchedules = mapper.Map<List<Schedule>>(settings.WateringSchedules);

            _context.SaveChanges();
        }

        public SettingsViewModel Settings(string deviceName, string deviceId, string location)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceViewModel>();
                cfg.CreateMap<Location, LocationViewModel>();
                cfg.CreateMap<List<Device>, List<DeviceViewModel>>();
                cfg.CreateMap<Settings, SettingsViewModel>();
                cfg.CreateMap<Schedule, ScheduleViewModel>();
                cfg.CreateMap<List<Schedule>, List<ScheduleViewModel>>();
            });

            var settings = _context.Settings.Include(x => x.Device).
                                             Include(x => x.Device.Location).
                                             Where(x => x.Device.Name == deviceName &&
                                             x.Device.Location.Name == location &&
                                             x.Device.DeviceId == deviceId).FirstOrDefault();

            if(settings == null) { return null; }

            var mapper = new Mapper(config);
            var settingsViewModel = mapper.Map<SettingsViewModel>(settings);

            return settingsViewModel;
        }
    }
}
