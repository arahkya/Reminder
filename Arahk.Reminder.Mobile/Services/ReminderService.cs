using System.Net.Http.Json;
using Arahk.Reminder.Mobile.Models;

namespace Arahk.Reminder.Mobile.Services;

public class ReminderService
{    
    public async Task<IEnumerable<ReminderListItemModel>> ListReminderAsync(CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient();
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5182/Reminder"));
        var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken);

        httpResponse.EnsureSuccessStatusCode();

        var reminderItems = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<ReminderListItemModel>>(cancellationToken) ?? [];

        return reminderItems;
    }
}