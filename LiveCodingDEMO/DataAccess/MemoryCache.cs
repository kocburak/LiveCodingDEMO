namespace LiveCodingDEMO.DataAccess
{
    public class MemoryCache : ICache
    {
        public T GetData<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool HasKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, object data)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
