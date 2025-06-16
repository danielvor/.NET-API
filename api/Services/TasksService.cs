using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Api.Models;

namespace Api.Services
{
    public class TasksService
    {
        private readonly IMongoCollection<TaskItem> _tasksCollection;

        public TasksService(IOptions<TodoDatabaseSettings> todoDatabaseSettings)
        {
            var mongoClient = new MongoClient(todoDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(todoDatabaseSettings.Value.DatabaseName);
            _tasksCollection = mongoDatabase.GetCollection<TaskItem>(todoDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<TaskItem>> GetAsync() =>
            await _tasksCollection.Find(_ => true).ToListAsync();

        public async Task<TaskItem?> GetAsync(string id) =>
            await _tasksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TaskItem newTask) =>
            await _tasksCollection.InsertOneAsync(newTask);

        public async Task UpdateAsync(string id, TaskItem updatedTask) =>
            await _tasksCollection.ReplaceOneAsync(x => x.Id == id, updatedTask);

        public async Task RemoveAsync(string id) =>
            await _tasksCollection.DeleteOneAsync(x => x.Id == id);
    }
}