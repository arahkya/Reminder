using System.Net.Http.Headers;
using System.Net.Http.Json;
using Arahk.Reminder.Mobile.Models;

namespace Arahk.Reminder.Mobile.Services;

public class ReminderService
{
#if DEBUG
    private const string BaseRestAddress = "http://localhost:5182";
#else
    private const string BaseRestAddress = "https://arahk-reminder.azurewebsites.net";
#endif
    
    public async Task<IEnumerable<ReminderListItemModel>> ListReminderAsync(CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient();
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, new Uri($"{BaseRestAddress}/Reminder"));
        var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken);
    
        httpResponse.EnsureSuccessStatusCode();
    
        var reminderItems = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<ReminderListItemModel>>(cancellationToken) ?? [];
    
        return reminderItems;
    }

    public async Task AddReminderEntryAsync(ReminderEntryModel model, CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient();
        var jsonContent = JsonContent.Create(model, new MediaTypeHeaderValue("application/json"));
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, new Uri($"{BaseRestAddress}/Reminder"));
        
        httpRequest.Content = jsonContent;
    
        var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken);
    
        httpResponse.EnsureSuccessStatusCode();
    }
}