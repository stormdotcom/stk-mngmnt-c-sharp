using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using api.Models;

namespace api.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class StockTransactionController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockTransactionController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(StockTransaction transaction)
        {
            var result = await _stockService.AddTransactionAsync(transaction);

            if (!result)
            {
                return NotFound("Stock not found for this transcation");
            }
            return Ok(transaction);
        }
    }
}
