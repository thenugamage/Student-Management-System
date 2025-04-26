using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace student_management_system.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;
    }
}