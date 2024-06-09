using System.Collections.ObjectModel;
using Arahk.Reminder.Mobile.Services;
using CommunityToolkit.Mvvm.Messaging;
using Foundation;

namespace Arahk.Reminder.Mobile.Models;

public class ReminderListModel
{
    private readonly ReminderService _reminderService; 
    
    public ObservableCollection<ReminderListItemModel> Items { get; set; } =
        new ObservableCollection<ReminderListItemModel>([]);

    public ReminderListModel(ReminderService reminderService)
    {
        _reminderService = reminderService;

        WeakReferenceMessenger.Default.Register<ReminderListItemModel>(this,MessagingHandler);
    }

    private async void MessagingHandler(object obj, ReminderListItemModel sender)
    {
        await LoadReminderItemsAsync();
    }
    
    public async Task LoadReminderItemsAsync()
    {
        Items.Clear();
        
        foreach (var reminderItem in await _reminderService.ListReminderAsync(CancellationToken.None))
        {
            Items.Add(reminderItem);   
        }
    }
}