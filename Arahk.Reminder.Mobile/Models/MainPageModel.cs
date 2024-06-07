using System.Collections.ObjectModel;
using Arahk.Reminder.Mobile.Views;

namespace Arahk.Reminder.Mobile.Models;

public class MainPageModel
{
    private readonly INavigation _navigator;
    public ObservableCollection<ReminderListItemModel> Items { get; set; }
    public Command NavToReminderEntryViewCommand { get; set; }

    public MainPageModel(INavigation navigator)
    {
        _navigator = navigator;
        NavToReminderEntryViewCommand = new Command(NavToReminderEntryView);
        Items = new ObservableCollection<ReminderListItemModel>([]);
    }

    public async Task LoadReminderItems()
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
    
    private void NavToReminderEntryView()
    {
        this._navigator.PushAsync(new ReminderEntryView());
    }
}