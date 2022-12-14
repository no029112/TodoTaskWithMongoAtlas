using MongoDB.Bson;
using MongoDB.Driver;
using TodoTasksServer.Models;
using TodoTasksServer.Util;

namespace TodoTasksServer.Services
{
    public class TaskService
    {
        readonly MongoDBService _mngdb;
        public TaskService(MongoDBService mngdb)
        {
            _mngdb = mngdb;
        }

        public async Task<List<TaskModel>> GetCustomerTasks(string customerID)
        {
            //var filter = Builders<TasksEntity>.Filter;
            //var filters = new List<FilterDefinition<TasksEntity>>();
            //var bson = new BsonDocument();
            //FilterDefinition<TasksEntity> cmd = null;
            //IOrderedFindFluent<TasksEntity, TasksEntity> query;
            //filter.And( filter.Eq(f => f.CustomerID , customerID));
            //filter.And(filter.Eq(f => f.IsActive, true));
            var taskCols =  _mngdb.database.GetCollection<TasksEntity>("tasks");
          //var customerTasks =  await taskCols.Find(x => x.CustomerID == customerID && x.IsActive ).ToListAsync();
            var customerTasks = await taskCols.Find(new  BsonDocument()).ToListAsync();
            if (customerTasks.Count > 0)
            {
                return Extension.ConvertToModel<List<TaskModel>>(customerTasks);
            }
            return new List<TaskModel>();

        }

        public async Task<(bool , string)> SaveNewTask(string title,string desc, string custID)
        {
            var task = new TasksEntity()
            {
                CustomerID = custID,
                Title = title,
                Description = desc,
                CreateDate = DateTime.Now,
                IsActive = true,
                isDone = false,
                UpdateDate = DateTime.Now,
            };
             var result =await _mngdb.AddAsync(task);

            return (status :result.Item1,message : result.Item2);

        }

    }
}
