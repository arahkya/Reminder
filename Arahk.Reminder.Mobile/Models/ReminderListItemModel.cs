using System.Windows.Input;
using Arahk.Reminder.Mobile.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Arahk.Reminder.Mobile.Models;

public class ReminderListItemModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    
    public ICommand DeleteCommand { get; set; }

    public ReminderListItemModel()
    {
        DeleteCommand = new AsyncRelayCommand(DeleteCommandHandler);
    }
    
    private async Task DeleteCommandHandler()
    {
        var reminderService = new ReminderService();
        await reminderService.DeleteReminderAsync(Id, CancellationToken.None);

        WeakReferenceMessenger.Default.Send(this);
    }
}