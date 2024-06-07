namespace Arahk.Reminder.Mobile.Models;

public class ReminderEntryModel
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime AlertOn { get; set; } = DateTime.Now.AddMinutes(30);
    public TimeSpan AlertTime { get; set; }
}