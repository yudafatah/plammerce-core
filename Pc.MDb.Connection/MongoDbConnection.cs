using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Pc.Mdb.Connection.Interfaces;
using System;
using System.Threading.Tasks;

namespace Pc.MDb.Connection
{
    public abstract class MongoDbConnection : IMongoDbConnection
    {
        public IMongoDatabase Db { get; }

        protected MongoDbConnection(string connectionString, WriteConcern writeConcern)
        {
            ConventionRegistry.Register("camelCase", new ConventionPack { new CamelCaseElementNameConvention() }, t => true);
            ConventionRegistry.Register("IgnoreExtraElement", new ConventionPack { new IgnoreExtraElementsConvention(true) }, t => true);
            ConventionRegistry.Register("IgnoreNullProp", new ConventionPack { new IgnoreIfNullConvention(true) }, t => true);

            //BsonSerializer.RegisterSerializer<decimal>(new Decimal128Serializer());

            //ConventionRegistry.Register("IgnoreDefaultProp", new ConventionPack{ new IgnoreIfDefaultConvention( true) }, t => true);

            var mongoUrl = new MongoUrl(connectionString);
            var clientSettings = MongoClientSettings.FromUrl(mongoUrl);
            clientSettings.WriteConcern = writeConcern;
            clientSettings.DirectConnection = true;

            //clientSettings.ConnectionMode = !string.IsNullOrWhiteSpace(clientSettings.ReplicaSetName)
            //    ? ConnectionMode.ReplicaSet
            //    : ConnectionMode.Standalone;

            //clientSettings.UseSsl = false;
            clientSettings.MinConnectionPoolSize = 50;

            var client = new MongoClient(clientSettings);
            Db = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public async Task WithTransaction(Func<IClientSessionHandle, Task> action)
        {
            using var session = await Db.Client.StartSessionAsync();
            try
            {
                session.StartTransaction();
                await action.Invoke(session);
                session.CommitTransaction();
            }
            catch (Exception)
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        public bool IsServerAvaliable()
        {
            return Db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(3000);
        }
    }
}
