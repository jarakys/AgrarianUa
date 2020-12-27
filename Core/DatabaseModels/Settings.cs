using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Settings
    {

        public int Id { get; set; }

        public string Temperature { get; set; }

        public string AirHumidity { get; set; }

        public string SoilTemperature { get; set; }

        public bool Autowatering { get; set; }

        public bool AutoVentilation { get; set; }

        public bool AutoLighting { get; set; }

        public virtual List<Schedule> WateringSchedules { get; set; }

        public virtual List<Schedule> LightingSchedules { get; set; }

        public virtual int DeviceId { get; set; }

        public virtual Device Device { get; set; }

    }
}
