using Asp.net_Web_Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Web_Api.Interface
{
    public interface IProductService
    {
        Task<bool> CreateProductService(Product product);
        Task<IEnumerable<Product>> GetAllProductsService();
        Task<Product> GetProductByIdService(int id);
        Task<bool> UpdateProductByIdService(Product product);
        Task<bool> DeleteProductByIdService(int id);
    }
}
