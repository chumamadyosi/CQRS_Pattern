using CommandPattern.Commands.Interfaces;
using CommandPattern.Models;
using CommonData;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CommandPattern.Commands.Handlers
{
    public class ProductCommand : IProductCommand
    {
        private AppDbContext _db;
        public ProductCommand(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteProduct(int Id)
        {
            Product product = _db.Products.Find(Id);

            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ProductCommandModel> InsertProduct(ProductCommandModel model)
        {
            Product product = new Product
            {
                Name = model.Name,
                Descripton = model.Descripton,
                Price = model.Price
            };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            model.ProductId = product.ProductId;
            return model;


        }

        public async Task<bool> UpdateProduct(ProductCommandModel model)
        {
            Product product = _db.Products.Find(model.ProductId);
            if (product != null)
            {
                product.Name = model.Name;
                product.Descripton = model.Descripton;
                product.Price = model.Price;

                _db.Products.Update(product);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;



        }
    }
}
