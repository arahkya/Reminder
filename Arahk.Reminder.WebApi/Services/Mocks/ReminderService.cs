using Arahk.Reminder.WebApi.Services.Models;

namespace Arahk.Reminder.WebApi.Services.Mocks;

public class ReminderService : IReminderService
{
    private readonly List<ReminderModel> _models = [];

    public ReminderService()
    {
        _models.Clear();
        for (var i = 1; i <= 20; i++)
        {   
            _models.Add(new ReminderModel()
            {
                Id = i,
                Title = $"Reminder Item {i}",
                Subtitle = "Created by Someone",
                CreatedOn = DateTime.Now.AddMinutes((i * 2) * -1)
            });
        }
    }
    
    public async Task<IEnumerable<ReminderModel>> ListAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult(_models.OrderByDescending(p => p.CreatedOn));
    }

    public async Task AddAsync(ReminderModel model,CancellationToken cancellationToken)
    {
        model.Id = (_models.MaxBy(p => p.Id)?.Id ?? 0) + 1;
        
        _models.Add(model);

        await Task.Delay(1000, cancellationToken);
    }
}