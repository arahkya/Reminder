using System.Net.Http.Json;
using Arahk.Reminder.Mobile.Models;

namespace Arahk.Reminder.Mobile.Services;

public class ReminderService
{    
    public async Task<IEnumerable<ReminderListItemModel>> ListReminderAsync(CancellationToken cancellationToken)
    {
        try
        {
            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5182/Reminder"));
            // var httpRequest = new HttpRequestMessage(HttpMethod.Get, new Uri("https://arahk-reminder.azurewebsites.net/Reminder"));
            var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken);

            httpResponse.EnsureSuccessStatusCode();

            var reminderItems = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<ReminderListItemModel>>(cancellationToken) ?? [];

            return reminderItems;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<ReminderListItemModel>> ListReminderAsyncMock(CancellationToken cancellationToken)
    {
        List<ReminderListItemModel> _models = [];
        
        for (var i = 1; i <= 20; i++)
        {
            await Task.Delay(10, cancellationToken);
            
            _models.Add(new ReminderListItemModel()
            {
                Title = $"Reminder Item {i}",
                Subtitle = "Created by Someone"
            });
        }

        return _models;
    }
}