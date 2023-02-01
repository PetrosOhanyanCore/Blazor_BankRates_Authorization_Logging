using AraratBankRatesAPI.Models.Domain;
using AraratBankRatesAPI.Models.DTO;
using AraratBankRatesAPI.Repositories.Abstract;
using AraratBankRatesAPI.Repositories.Domain;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AraratBankRatesAPI.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILoggerManager _logger;
        private readonly ITransactionService _transactionService;

        public TransactionsController(UserManager<ApplicationUser> userManager,
            ILoggerManager logger,
            ITransactionService transactionService)
        {
            this._userManager = userManager;
            this._logger = logger;
            this._transactionService = transactionService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionRequest request)
        {
            _logger.LogInfo("TransactionsController/Creat");

            var userClaim = this.User;
            var user = await _userManager.FindByNameAsync(userClaim.Identity.Name);
            //var user = await _userManager.GetUserAsync(userClaim);

            request.UserId = user.Id;
            try
            {
                await _transactionService.Create(request);
            }
            catch (Exception ex)
            {
                _logger.LogError($"TransactionsController/Creat {request.UserId}, {request.CreatedDate}");
                return Ok(ex);
            }

            _logger.LogInfo($"TransactionsController/Creat {request.UserId}, {request.CreatedDate}");
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            _logger.LogInfo("TransactionsController/List");

            var userClaim = this.User;
            var user = await _userManager.GetUserAsync(userClaim);

            var userId = user.Id;
            var response = new List<TransactionResponse>();

            try
            {
                response = await _transactionService.GetAll(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"TransactionsController/List {userId}");
                return Ok(ex);
            }

            _logger.LogInfo($"TransactionsController/List {userId}");
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInfo("TransactionsController/GetById");

            var userClaim = this.User;
            var user = await _userManager.GetUserAsync(userClaim);

            var userId = user.Id;
            var response = new TransactionResponse();

            try
            {
                response = await _transactionService.GetById(userId, id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"TransactionsController/GetById {userId},{id}");
                return Ok(ex);
            }

            _logger.LogInfo($"TransactionsController/GetById {userId},{id}");
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] Calculate request)
        {
            double result = 0;
            try
            {
                RateModel rateModel = new();
                rateModel = await _transactionService.GetRates();

                double givenAmount = request.GivedAmount;
                string givenExchangeType = request.GivedExchange.ExchangeType;
                string receivenExchangeType = request.ReceivenExchange.ExchangeType;


                result = await _transactionService.Calculate(givenAmount, givenExchangeType, receivenExchangeType, rateModel);
            }
            catch (Exception)
            {
                _logger.LogError($"TransactionsController/Calculate");
                return Problem();
            }

            _logger.LogInfo("TransactionsController/Calculate");
            return Ok(result);

        }
    }
}
