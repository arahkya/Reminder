using Arahk.Reminder.Mobile.Models;
using Arahk.Reminder.Mobile.Services;

namespace Arahk.Reminder.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        this.BindingContext = new MainPageModel(Navigation,new ReminderService());
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ((MainPageModel)BindingContext).InitializeAsync();
    }
}