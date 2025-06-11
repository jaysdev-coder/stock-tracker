namespace StockTracker.Data;

public class StockService {
      StockDbContext _context;
      public StockService(StockDbContext context) {
        _context = context;
      }

      public async Task<List<Stock>> GetStocksAsync() {
        var result = _context.Stocks;
        return await Task.FromResult(result.ToList());
      }

      public async Task<Stock> GetStockByIdAsync(string id) {
        return await _context.Stocks.FindAsync(id);
      }

      public async Task<Stock> InsertStockAsync(Stock Stock) {
        _context.Stocks.Add(Stock);
        await _context.SaveChangesAsync();

        return Stock;
      }

      public async Task<Stock> UpdateStockAsync(string id, Stock s) {
        var Stock = await _context.Stocks.FindAsync(id);
        
        if (Stock == null)
          return null;

        Stock.ticker = s.ticker;

        _context.Stocks.Update(Stock);
        await _context.SaveChangesAsync();

        return Stock;
      }

      public async Task<Stock> DeleteStockAsync(string id)
      {
        var Stock = await _context.Stocks.FindAsync(id);
        
        if (Stock == null)
          return null;

        _context.Stocks.Remove(Stock);
        await _context.SaveChangesAsync();

        return Stock;
      }

      public bool StockExists(string ticker) {
        return _context.Stocks.Any(e => e.ticker == ticker);
      }
}
