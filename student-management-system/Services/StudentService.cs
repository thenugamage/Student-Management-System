using Microsoft.Extensions.Options;
using MongoDB.Driver;
using student_management_system.Models;

namespace student_management_system.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IConfiguration config)
        {
            // 1. Get connection settings from configuration
            var client = new MongoClient(config["MongoDBSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDBSettings:DatabaseName"]);

            // 2. Get the collection
            _students = database.GetCollection<Student>(config["MongoDBSettings:CollectionName"]);
        }

        public async Task<List<Student>> GetAsync() =>
            await _students.Find(s => true).ToListAsync();

        public async Task<Student?> GetAsync(string id) =>
            await _students.Find(s => s.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Student student) =>
            await _students.InsertOneAsync(student);

        public async Task UpdateAsync(string id, Student updatedStudent) =>
            await _students.ReplaceOneAsync(s => s.Id == id, updatedStudent);

        public async Task DeleteAsync(string id) =>
            await _students.DeleteOneAsync(s => s.Id == id);
    }
}