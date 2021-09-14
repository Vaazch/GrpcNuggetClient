namespace GrpcClientSample.Controllers;
using GrpcClientNugget;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GreeterController : ControllerBase
{
    private readonly ILogger<GreeterController> _logger;
    private readonly GreeterClientService _greeterClientService;

    public GreeterController(ILogger<GreeterController> logger, GreeterClientService greeterClientService)
    {
        _logger = logger;
        _greeterClientService = greeterClientService;

    }

    [HttpPost]
    public async Task<string> RequestGreet(string name)
    {
        _logger.LogInformation($"Requesting Greet with {name} name!");
        return await _greeterClientService.RequestGreet(name);
    }
}
