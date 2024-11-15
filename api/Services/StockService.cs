using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class StockService
    {
        private readonly ApplicationDBContext _context;
        public StockService(ApplicationDBContext context)
        {
            _context = context;
        }
        // public async Task<List<Stock>> GetAllStocksAsync() => await _context.Stock.Include(s => s.Comments).ToListAsync();

        public async Task<List<StockDTO>> GetAllStocksAsync()
        {
            var stocks = await _context.Stock.ToListAsync();


            return stocks.Select(s => s.ToStockDTO()).ToList();
        }
        public async Task<Stock?> GetStockByIdAsync(int id) => await _context.Stock.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        public async Task<StockDTO> AddStockAsync(CreateStockDTO createStockDTO)
        {
            var stockEntity = createStockDTO.ToStockEntity();
            _context.Stock.Add(stockEntity);
            await _context.SaveChangesAsync();
            return stockEntity.FromStockDTO();
        }
        public async Task<StockDTO> UpdateStockAsync(int id, StockDTO updatedStockDto)
        {

            var existingStock = await _context.Stock.FindAsync(id);
            if (existingStock == null) return null!;

            existingStock.Symbol = updatedStockDto.Symbol;
            existingStock.CompanyName = updatedStockDto.CompanyName;
            existingStock.Purchase = updatedStockDto.Purchase;
            existingStock.LastDiv = updatedStockDto.LastDiv;
            existingStock.Industry = updatedStockDto.Industry;
            existingStock.MarketCap = updatedStockDto.MarketCap;
            _context.Stock.Update(existingStock);

            await _context.SaveChangesAsync();

            return existingStock.ToStockDTO();

        }
        public async Task DeleteStockAsync(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            if (stock != null)
            {
                _context.Stock.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> AddTransactionAsync(StockTransaction transaction)
        {
            var stock = await _context.Stock.FindAsync(transaction.StockId);
            if (stock == null)
            {
                return false;
            }

            _context.StockTransactions.Add(transaction);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<StockSummaryDTO>> GetSockSummaryAsync()
        {
            return await _context.Stock.Select(s => s.ToStockSummaryDTO()).ToListAsync();
        }
    }
}