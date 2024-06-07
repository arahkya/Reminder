using Arahk.Reminder.Mobile.Models;
using Arahk.Reminder.Mobile.Views;

namespace Arahk.Reminder.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        this.BindingContext = new MainPageModel(Navigation);
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ((MainPageModel)BindingContext).LoadReminderItems();
    }
}