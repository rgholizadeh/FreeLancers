using FreeLancersWebApi.Modells;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FreeLancersWebApi.Services
{
    public class FreeLancerService
    {
        private readonly IMongoCollection<FreeLancer> _freelancer;

        //public FreeLancerService(IFreeLancersDatabaseSettings settings, IMongoClient mongoClient)
        //{
        //    var database = mongoClient.GetDatabase(settings.DatabaseName);
        //    _freelancer = database.GetCollection<FreeLancer>(settings.CollectionName);
        //}
        public FreeLancerService(IOptions<FreeLancersDatabaseSettings> freeLancersDatabaseSettings)
        {
            var mongoClient = new MongoClient(freeLancersDatabaseSettings.Value.ConnectionString);

            //var mongoDatabase = mongoClient.GetDatabase(
            //    freeLancersDatabaseSettings.Value.DatabaseName);

            //_freelancer = mongoDatabase.GetCollection<FreeLancer>(
            //    freeLancersDatabaseSettings.Value.FreeLancersCollectionName);
            _freelancer = mongoClient.GetDatabase(freeLancersDatabaseSettings.Value.DatabaseName)
                .GetCollection<FreeLancer>(
                freeLancersDatabaseSettings.Value.FreeLancersCollectionName);
        }
        public async Task<List<FreeLancer>> Get() =>
            await _freelancer.Find(freelancer => true).ToListAsync();

        public async Task<FreeLancer?> Get(Guid id) =>
            await _freelancer.Find(freelancer => freelancer.id == id).FirstOrDefaultAsync();

        public async Task Create(FreeLancer newFreeLancer) =>
            await _freelancer.InsertOneAsync(newFreeLancer);

        public async Task Update(Guid id, FreeLancer updateFreeLancer) =>
           await _freelancer.ReplaceOneAsync(freelancer => freelancer.id == id, updateFreeLancer);

        public async Task Remove(Guid id) =>
           await _freelancer.DeleteOneAsync(freelancer => freelancer.id == id);

    }
}
