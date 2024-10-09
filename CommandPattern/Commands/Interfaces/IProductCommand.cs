using CommandPattern.Models;
using System.Threading.Tasks;

namespace CommandPattern.Commands.Interfaces
{
    public interface IProductCommand
    {
        Task<ProductCommandModel> InsertProduct(ProductCommandModel product);
        Task<bool> UpdateProduct(ProductCommandModel product);
        Task<bool> DeleteProduct(int Id);

    }
}
