using System.Collections.Generic;

namespace AgrarianUa.ViewModels
{
    public class LocationViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<DeviceViewModel> Devices { get; set; }

        public LocationViewModel(int id, string name, List<DeviceViewModel> devices = null)
        {
            Id = id;
            Name = name;
            Devices = devices ?? new List<DeviceViewModel>();
        }
    }
}
