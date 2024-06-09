using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arahk.Reminder.Mobile.Models;
using Arahk.Reminder.Mobile.Services;

namespace Arahk.Reminder.Mobile.Views;

public partial class ReminderEntryView : ContentPage
{
    public ReminderEntryView(ReminderService reminderService)
    {
        InitializeComponent();

        BindingContext = new ReminderEntryModel(reminderService, Navigation);
    }
}