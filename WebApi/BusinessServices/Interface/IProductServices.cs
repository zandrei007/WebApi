using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IProductServices
    {
        ProductEntity GetProductById(int productId);
        IEnumerable<ProductEntity> GetAllProducts();
        int CreateProduct(ProductEntity productEntity);
        bool UpdateProduct(int productId, ProductEntity productEntity);
        bool DeleteProduct(int productId);
    }
}
