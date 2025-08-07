using Asp.net_Web_Api.Data;
using Asp.net_Web_Api.Entities;
using Asp.net_Web_Api.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Web_Api.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbcontext;
        public ProductService(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CreateProductService(Product product)
        {
            _dbcontext.Products.Add(product);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Product>> GetAllProductsService()
        {
            var all = await _dbcontext.Products.ToListAsync();
            return all;
        }
        public async Task<bool> DeleteProductByIdService(int id)
        {
            var deletedItem = await _dbcontext.Products.
                FirstOrDefaultAsync(x => x.Id == id);
            if (deletedItem == null)
            {

                return false;
            }
            else
                _dbcontext.Products.Remove(deletedItem);
            await _dbcontext.SaveChangesAsync();
            return true;
        }



        public async Task<bool> UpdateProductByIdService(Product product)
        {
            var updatedItem = await _dbcontext.Products.
                 FindAsync(product.Id);

            if (updatedItem == null)
            {

                return false;

            }
            else

                updatedItem.Name = product.Name;
            updatedItem.Quantity = product.Quantity;
            updatedItem.Price = product.Price;

            _dbcontext.Products.Update(updatedItem);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<Product> GetProductByIdService(int id)
        {
            var Item = await _dbcontext.Products.
               FindAsync(id);
            return Item;

        }
    }
}
