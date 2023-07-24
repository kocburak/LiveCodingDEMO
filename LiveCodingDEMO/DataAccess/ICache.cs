using Microsoft.AspNetCore.SignalR;

namespace LiveCodingDEMO.DataAccess
{
    public interface ICache
    {
        T GetData<T>(string key);
        void Insert(string key, object data);
        bool HasKey(string key);
        void Remove(string key);
    }
}
