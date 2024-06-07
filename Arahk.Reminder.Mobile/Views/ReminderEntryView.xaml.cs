using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arahk.Reminder.Mobile.Models;

namespace Arahk.Reminder.Mobile.Views;

public partial class ReminderEntryView : ContentPage
{
    public ReminderEntryView()
    {
        InitializeComponent();

        BindingContext = new ReminderEntryModel();
    }
}