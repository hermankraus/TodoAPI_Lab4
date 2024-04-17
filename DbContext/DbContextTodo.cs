using Microsoft.EntityFrameworkCore;
using TodoAPI.Entities;

namespace TodoAPI.dbContext
{
    public class DbContextTodo : DbContext
    {
        public DbContextTodo(DbContextOptions<DbContextTodo> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "herman",
                    Email = "herman@gmail.com",
                    Address = "asdsa 123"
                },
                new User
                {
                    Id = 2,
                    Name = "u2",
                    Email = "u2@gmail.com",
                    Address = "asdsaasddasdsa 123"
                },
                new User
                {
                    Id = 3,
                    Name = "u3",
                    Email = "u3@gmail.com",
                    Address = "aaaaasdsaasddasdsa 123"
                }
            );

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id_todo_item = 1,
                    Title = "pasear perro",
                    Description = "sacarlo a la noche",
                    UserId = 1
                },
                new TodoItem
                {
                    Id_todo_item = 2,
                    Title = "estudiar",
                    Description = "lab4",
                    UserId = 2
                },
                new TodoItem
                {
                    Id_todo_item = 3,
                    Title = "comer",
                    Description = "xd",
                    UserId = 1
                }
            );

            modelBuilder.Entity<TodoItem>()
                .HasOne(t => t.User)
                .WithMany(u => u.TodoItems)
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
