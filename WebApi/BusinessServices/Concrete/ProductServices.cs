using BusinessServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices.Concrete
{
    /// <summary>
    /// Offers services for product specific CRUD operations
    /// </summary>
    public class ProductServices : IProductServices
    {
        public int CreateProduct(ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductEntity GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(int productId, ProductEntity productEntity)
        {
            throw new NotImplementedException();
        }
    }
}
