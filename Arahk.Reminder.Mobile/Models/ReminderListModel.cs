using System.Collections.ObjectModel;
using Arahk.Reminder.Mobile.Services;

namespace Arahk.Reminder.Mobile.Models;

public class ReminderListModel(ReminderService reminderService)
{
    private readonly ReminderService _reminderService = reminderService; 
    
    public ObservableCollection<ReminderListItemModel> Items { get; set; } =
        new ObservableCollection<ReminderListItemModel>([]);
    
    public async Task LoadReminderItemsAsync()
    {
        Items.Clear();
        
        foreach (var reminderItem in await reminderService.ListReminderAsync(CancellationToken.None))
        {
            Items.Add(reminderItem);   
        }
    }
}