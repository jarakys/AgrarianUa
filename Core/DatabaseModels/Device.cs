using System;
namespace Core.Models
{
    public class Device
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DeviceId { get; set; }

        public virtual Location Location { get; set; }

        public virtual Settings Settings { get; set; }
    }
}
