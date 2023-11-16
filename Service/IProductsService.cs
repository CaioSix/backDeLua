using DeLua.Data.Entities;
using DeLua.Data.ValueObjects;

namespace DeLua.Service
{
    public interface IProductsService
    {

        
         Task<List<ProductVO>> PegarTodosOsProdutos();
   
    }
}
