using Arahk.Reminder.WebApi.Services.Models;

namespace Arahk.Reminder.WebApi.Services;

public interface IReminderService
{
    Task<IEnumerable<ReminderModel>> ListAsync(CancellationToken cancellationToken);
    Task AddAsync(ReminderModel model, CancellationToken cancellationToken);
}