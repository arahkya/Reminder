using Arahk.Reminder.Mobile.Views;

namespace Arahk.Reminder.Mobile.Models;

public class MainPageModel
{
    private readonly INavigation _navigator;
    
    public Command NavToReminderEntryViewCommand { get; set; }

    public MainPageModel(INavigation navigator)
    {
        _navigator = navigator;
        NavToReminderEntryViewCommand = new Command(NavToReminderEntryView);
    }
    
    private void NavToReminderEntryView()
    {
        this._navigator.PushAsync(new ReminderEntryView());
    }
}