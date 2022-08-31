using MongoDB.Bson;
using MongoDB.Driver;
using TodoTasksServer.Models;

namespace TodoTasksServer.Services
{
    public class UserService
    {
        readonly MongoDBService _mngdb;
        public UserService(MongoDBService mngdb)
        {
            _mngdb = mngdb;
        }
        public async Task CreateNewUser()
        {
             var a = await GetAccount();
        }

        public async Task<( IEnumerable<AccountsEntity>, string)> GetAccount() => await _mngdb.GetAsync<AccountsEntity>();
    }
}
