using System.Collections.ObjectModel;
using Arahk.Reminder.Mobile.Services;
using Arahk.Reminder.Mobile.Views;

namespace Arahk.Reminder.Mobile.Models;

public class MainPageModel
{
    private readonly INavigation _navigator;
    
    public ReminderListModel ReminderList { get; set; }
    public Command NavToReminderEntryViewCommand { get; set; }

    public MainPageModel(INavigation navigator,ReminderService reminderService)
    {
        _navigator = navigator;
        ReminderList = new ReminderListModel(reminderService);
        NavToReminderEntryViewCommand = new Command(NavToReminderEntryView);
    }

    public async Task InitializeAsync()
    {
        await ReminderList.LoadReminderItemsAsync();
    }
    
    private void NavToReminderEntryView()
    {
        this._navigator.PushAsync(new ReminderEntryView());
    }
}