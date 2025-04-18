using Catalog.API.Models;
using MongoRepo.Interfaces.Manager;

namespace Catalog.API.Interface.Manager
{
    public interface IProductManager:ICommonManager<Product>
    {
        List<Product> GetByCategory(string category);
    }
}
