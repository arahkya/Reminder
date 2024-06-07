using System.Collections.ObjectModel;
using Arahk.Reminder.Mobile.Services;

namespace Arahk.Reminder.Mobile.Models;

public class ReminderListModel(ReminderService reminderService)
{
    private readonly ReminderService _reminderService = reminderService; 
    
    public ObservableCollection<ReminderListItemModel> Items { get; set; } =
        new ObservableCollection<ReminderListItemModel>([]);
    
    public async Task MockLoadReminderItemsAsync()
    {
        await Task.Delay(100);

        Items.Clear();
        
        for (var i = 0; i < 10; i++)
        {
            await Task.Delay(10);
            Items.Add(new ReminderListItemModel()
            {
                Title = $"Reminder Item {i}",
                Subtitle = "Created by Someone"
            });
        }
    }
    
    public async Task LoadReminderItemsAsync()
    {
        Items.Clear();
        
        foreach (var reminderItem in await reminderService.ListReminderAsync(CancellationToken.None))
        {
            Items.Add(reminderItem);   
        }
    }
}