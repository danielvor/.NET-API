using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    [BsonIgnoreExtraElements] // Ignora campos extras do MongoDB, como '_class'
    public class TaskItem
    {
        [BsonId] // Marca esta propriedade como o ID primário do MongoDB
        [BsonRepresentation(BsonType.ObjectId)] // Especifica que o ID deve ser armazenado como ObjectId
        public string? Id { get; set; }

        [BsonElement("title")] // Mapeia para o campo 'title' no MongoDB
        public string Title { get; set; } = null!;

        [BsonElement("content")] // Mapeia para o campo 'content' no MongoDB
        public string Content { get; set; } = null!;
    }
}