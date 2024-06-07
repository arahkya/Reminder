using Arahk.Reminder.WebApi.Services.Models;

namespace Arahk.Reminder.WebApi.Services.Mocks;

public class ReminderService : IReminderService
{
    private readonly List<ReminderModel> _models = [];
    
    public async Task<IEnumerable<ReminderModel>> ListAsync(CancellationToken cancellationToken)
    {
        for (var i = 1; i <= 10; i++)
        {
            await Task.Delay(10, cancellationToken);
            
            _models.Add(new ReminderModel()
            {
                Id = i,
                Title = $"Reminder Item {i}",
                Subtitle = "Created by Someone"
            });
        }

        return _models;
    }
}