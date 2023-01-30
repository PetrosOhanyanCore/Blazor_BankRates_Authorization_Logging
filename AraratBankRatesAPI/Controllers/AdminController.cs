using AraratBankRatesAPI.Models.DTO;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AraratBankRatesAPI.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public AdminController(ILoggerManager logger)
        {
            _logger= logger;
        }
        public IActionResult GetData()
        {
            _logger.LogInfo("AdminController/GetDate");
            var status = new Status();
            status.StatusCode = 1;
            status.Message = "Data from admin controller";
            _logger.LogInfo(status.ToString());
            return Ok(status);
        }
    }
}
