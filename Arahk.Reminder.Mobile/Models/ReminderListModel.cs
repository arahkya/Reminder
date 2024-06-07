using System.Collections.ObjectModel;

namespace Arahk.Reminder.Mobile.Models;

public class ReminderListModel
{
    public ObservableCollection<ReminderListItemModel> Items { get; set; } =
        new ObservableCollection<ReminderListItemModel>([]);
    
    public async Task LoadReminderItemsAsync()
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
}