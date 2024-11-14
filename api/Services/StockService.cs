using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
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
        public async Task<List<Stock>> GetAllStocksAsync() => await _context.Stock.Include(s => s.Comments).ToListAsync();
        public async Task<Stock?> GetStockByIdAsync(int id) => await _context.Stock.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        public async Task AddStockAsync(Stock stock)
        {
            _context.Stock.Add(stock);
            await _context.SaveChangesAsync();

        }
        public async Task<bool> UpdateStockAsync(Stock stock)
        {
            var exists = await _context.Stock.AnyAsync(s => s.Id == stock.Id);
            if (!exists)
            {
                return false;
            }
            _context.Stock.Update(stock);

            await _context.SaveChangesAsync();
            return true;
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
    }
}