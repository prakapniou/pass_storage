using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PasswordStorage.Web.Models;

namespace PasswordStorage.Web.Services;

public class PasswordService
{
    private readonly IMongoCollection<Profile> _passwordCollection;
    public PasswordService(IOptions<PasswordStorageDataBaseSettings> settings)
    {
        var mongoClient=new MongoClient(settings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _passwordCollection=mongoDatabase.GetCollection<Profile>(settings.Value.PasswordCollectionName);        
    }
    
    public async Task<List<Profile>> GetAsync()=>
        await _passwordCollection.Find(_=>true).ToListAsync();

    public async Task<Profile> GetAsync(Guid id)=>
        await _passwordCollection.Find(_=>_.Id.Equals(id)).FirstOrDefaultAsync();

    public async Task CreateAsync(Profile profile)=>
        await _passwordCollection.InsertOneAsync(profile);

    public async Task UpdateAsync(Guid id, Profile profile) =>
        await _passwordCollection.ReplaceOneAsync(_=>_.Id.Equals(id),profile);

    public async Task RemoveAsync(Guid id) =>
        await _passwordCollection.DeleteOneAsync(_=>_.Id.Equals(id));
}
