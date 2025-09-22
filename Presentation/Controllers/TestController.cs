using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Management_System.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping() => Ok("pong");

    [HttpGet("auth")]
    [Authorize]
    public IActionResult Auth() => Ok("Authorized!");
}