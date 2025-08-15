using System.ComponentModel.DataAnnotations.Schema;
using ReporitorySqlServer.Entities.Constants;

namespace ReporitorySqlServer.Entities
{
    [Table("Customers")]
    public class CustomersEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
