using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Pc.Mdb.Connection.Interfaces
{
    public interface IMongoDbConnection
    {
        IMongoDatabase Db { get; }

        Task WithTransaction(Func<IClientSessionHandle, Task> action);

        bool IsServerAvaliable();
    }
}