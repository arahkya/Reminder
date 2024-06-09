using Arahk.Reminder.WebApi.Services;
using Arahk.Reminder.WebApi.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arahk.Reminder.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReminderController(ILogger<ReminderController> logger, IReminderService reminderService)
    : ControllerBase
{
    private readonly ILogger<ReminderController> _logger = logger;
    private readonly IReminderService _reminderService = reminderService;

    [HttpGet(Name = "Get Reminder Models")]
    public async Task<IEnumerable<ReminderModel>> Get(CancellationToken cancellationToken)
    {
        var models = await _reminderService.ListAsync(cancellationToken);

        return models;
    }

    [HttpPost(Name = "Add Reminder Model")]
    public async Task Post([FromBody]ReminderModel model, CancellationToken cancellationToken)
    {
        await _reminderService.AddAsync(model, cancellationToken);
    }

    [Route("{id:int}")]
    [HttpDelete(Name = "Delete Reminder Model")]
    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        await _reminderService.DeleteAsync(id, cancellationToken);
    }
}