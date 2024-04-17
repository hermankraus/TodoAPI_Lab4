using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Entities
{
    public class TodoItem
    {
        [Key]
        public int Id_todo_item { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
