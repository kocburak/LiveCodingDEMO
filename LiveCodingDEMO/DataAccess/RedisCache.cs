using StackExchange.Redis;
using System.Runtime.CompilerServices;

namespace LiveCodingDEMO.DataAccess
{
    public class RedisCache : ICache
    {
        private readonly IDatabase database;

        public RedisCache(IConfiguration configuration)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configuration["Redis:ConnectionString"]);
            database = redis.GetDatabase();
        }

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
