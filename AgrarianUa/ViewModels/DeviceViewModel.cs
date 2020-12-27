namespace AgrarianUa.ViewModels
{
    public class DeviceViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string DeviceId { get; set; }

        public LocationViewModel Location { get; set; }

        public SettingsViewModel Settings { get; set; }

        public DeviceViewModel(int id, string name, string deviceId, LocationViewModel location, SettingsViewModel settings)
        {
            Id = id;
            Name = name;
            DeviceId = deviceId;
            Location = location;
            Settings = settings;
        }
    }
}
