using APILibrary.Models;

namespace APILibrary.Utilities
{
    public interface IMyHttpService
    {
        Task<string> GetAllInProcessOrdersAsync();
        Task<List<OrdersModel>> GetTop5ProductsAsync();
        Task<bool> UpdateProductsStocksAsync(Product product);
    }
}