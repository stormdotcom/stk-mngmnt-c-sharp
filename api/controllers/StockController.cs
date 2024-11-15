using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;
        public StockController(StockService stockservice)
        {
            _stockService = stockservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _stockService.GetStockByIdAsync(id);
            return stock == null ? NotFound() : Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockDTO createStockDTO)
        {
            var stockDTO = await _stockService.AddStockAsync(createStockDTO);
            return CreatedAtAction(nameof(GetById), new { id = stockDTO.Id }, stockDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Stock stock)
        {
            if (id != stock.Id) return BadRequest();

            await _stockService.UpdateStockAsync(stock);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stockService.DeleteStockAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetStockSummary()
        {
            var stocks = await _stockService.GetSockSummaryAsync();
            return Ok(stocks);
        }
    }
}
