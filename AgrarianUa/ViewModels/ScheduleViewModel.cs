namespace AgrarianUa.ViewModels
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }

        public SettingsViewModel Settings { get; set; }

        public string Time { get; set; }

        public ScheduleViewModel(int id, SettingsViewModel settings, string time)
        {
            Id = id;
            Settings = settings;
            Time = time;
        }
    }
}
