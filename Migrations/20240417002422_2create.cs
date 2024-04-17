using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAPI.Migrations
{
    public partial class _2create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_todo_item", "Description", "Title", "UserId" },
                values: new object[] { 1, "sacarlo a la noche", "pasear perro", 1 });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_todo_item", "Description", "Title", "UserId" },
                values: new object[] { 2, "lab4", "estudiar", 2 });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_todo_item", "Description", "Title", "UserId" },
                values: new object[] { 3, "xd", "comer", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id_todo_item",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id_todo_item",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id_todo_item",
                keyValue: 3);
        }
    }
}
