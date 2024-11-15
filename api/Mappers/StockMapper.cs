using api.DTOs;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stockModel)
        {
            return new StockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }

        public static Stock ToStockEntity(this CreateStockDTO createStockDTO)
        {
            return new Stock
            {
                Symbol = createStockDTO.Symbol,
                CompanyName = createStockDTO.CompanyName,
                Purchase = createStockDTO.Purchase,
                LastDiv = createStockDTO.LastDiv,
                Industry = createStockDTO.Industry,
                MarketCap = createStockDTO.MarketCap
            };
        }
    }
}
