using System.Windows.Input;
using Arahk.Reminder.Mobile.Services;
using CommunityToolkit.Mvvm.Input;

namespace Arahk.Reminder.Mobile.Models;

public class ReminderEntryModel
{
    private readonly ReminderService _reminderService;
    private readonly INavigation _navigation;

    public ReminderEntryModel(ReminderService reminderService, INavigation navigation)
    {
        _reminderService = reminderService;
        _navigation = navigation;
        SaveEntryCommand = new AsyncRelayCommand(SaveEntryCommandHandler);
    }

    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime AlertOn { get; set; } = DateTime.Now.AddMinutes(30);
    public TimeSpan AlertTime { get; set; }
    
    public ICommand SaveEntryCommand { get; set; }

    private async Task SaveEntryCommandHandler()
    {
        await _reminderService.AddReminderEntryAsync(this, CancellationToken.None);
        await _navigation.PopAsync();
    }
}