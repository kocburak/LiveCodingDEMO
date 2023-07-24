using LiveCodingDEMO.Entities;

namespace LiveCodingDEMO.DataAccess
{
    public interface IRepository
    {
        void DeleteProduct(int id);
        void EditProduct(Product product);
        Product GetProduct(int id);
    }
}
