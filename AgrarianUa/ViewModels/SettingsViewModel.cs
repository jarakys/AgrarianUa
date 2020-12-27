using System.Collections.Generic;

namespace AgrarianUa.ViewModels
{
    public class SettingsViewModel
    {

        public int Id { get; set; }

        public string Temperature { get; set; }

        public string AirHumidity { get; set; }

        public string SoilTemperature { get; set; }

        public bool Autowatering { get; set; }

        public bool AutoVentilation { get; set; }

        public bool AutoLighting { get; set; }

        public List<ScheduleViewModel> WateringSchedules { get; set; }

        public List<ScheduleViewModel> LightingSchedules { get; set; }

        public DeviceViewModel Device { get; set; }

        public SettingsViewModel(int id, string temperature, string airHumidity, string soilTemperature, bool autowatering, bool autoVentilation, bool autoLighting, List<ScheduleViewModel> wateringSchedules, List<ScheduleViewModel> lightingSchedules, DeviceViewModel device)
        {
            Id = id;
            Temperature = temperature;
            AirHumidity = airHumidity;
            SoilTemperature = soilTemperature;
            Autowatering = autowatering;
            AutoVentilation = autoVentilation;
            AutoLighting = autoLighting;
            WateringSchedules = wateringSchedules;
            LightingSchedules = lightingSchedules;
            Device = device;
        }
    }
}
