using APILibrary.Models;

namespace APILibrary
{
    public interface IBusinessLogic
    {
        string GetInProgressOrders();
        List<Lines> GetTop5Products();

        bool updateProductStocks();
    }
}