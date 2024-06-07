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
}