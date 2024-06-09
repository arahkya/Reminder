namespace Arahk.Reminder.WebApi.Services.Models;

public class ReminderModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = DateTime.Now;
}