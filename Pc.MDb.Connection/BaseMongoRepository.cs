using Pc.MDb.Connection.Interfaces;

namespace Pc.MDb.Connection
{
    public class BaseMongoRepository
    {
        public BaseMongoRepository(IMarketplacePlantConnection conn)
        {
            Db = conn;
        }

        protected readonly IMarketplacePlantConnection Db;

    }
}