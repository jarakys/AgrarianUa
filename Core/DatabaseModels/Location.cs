using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Device> Devices { get; set; }
    }
}
