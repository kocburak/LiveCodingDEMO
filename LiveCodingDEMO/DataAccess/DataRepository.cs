using LiveCodingDEMO.Entities;
using System.Net.Http.Headers;
using System.Text;

namespace LiveCodingDEMO.DataAccess
{
    public class DataRepository : IRepository
    {
        private readonly ICache _cache;
        private readonly RepositoryContext _databaseContext;

        public DataRepository(ICache cache, RepositoryContext databaseContext)
        {
            _cache = cache;
            _databaseContext = databaseContext;
        }

        public Product GetProduct(int id)
        {
            string productCacheKey = RedisKeys.GetFormattedKey(RedisKeys.ProductDetailKey, id.ToString());
            if (_cache.HasKey(productCacheKey))
            {
                return _cache.GetData<Product>(productCacheKey);
            }

            Product? fetchedProduct = _databaseContext.Products.FirstOrDefault(e => e.Id == id);

            _cache.Insert(productCacheKey, fetchedProduct);

            return fetchedProduct;
        }

        public void EditProduct(Product product)
        {
            _databaseContext.Products.Update(product);
            _databaseContext.SaveChanges();

            string productCacheKey = RedisKeys.GetFormattedKey(RedisKeys.ProductDetailKey, product.Id.ToString());
            _cache.Remove(productCacheKey);
        }

        public void DeleteProduct(int id)
        {
            string productCacheKey = RedisKeys.GetFormattedKey(RedisKeys.ProductDetailKey, id.ToString());

            _databaseContext.Products.Remove(new Product()
            {
                Id = id
            });
            _databaseContext.SaveChanges();
            _cache.Remove(productCacheKey);
        }

    }


    public static class RedisKeys
    {
        public const string ProductDetailKey = "product-detail-%0";

        public static string GetFormattedKey(string key, params string[] values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(key);

            for (int i = 0; i < values.Length; i++)
            {
                stringBuilder.Replace("%" + i, values[i]);
            }
            return stringBuilder.ToString();

        }
    }
}
