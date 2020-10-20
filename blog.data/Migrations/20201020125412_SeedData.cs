using Microsoft.EntityFrameworkCore.Migrations;

namespace blog.data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Ali')");

            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Ahmet')");

            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Veli')");

            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Alper')");

            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Furkan')");

            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Selamlar olsun', (SELECT Id FROM Users WHERE Name = 'Ali'))");

            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Selamın Aleyküm', (SELECT Id FROM Users WHERE Name = 'Ahmet'))");

            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Allaha emanet', (SELECT Id FROM Users WHERE Name = 'Veli'))");

            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Kendinize iyi bakın', (SELECT Id FROM Users WHERE Name = 'Alper'))");

            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Not good at goodbyes', (SELECT Id FROM Users WHERE Name = 'Furkan'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Posts");
            migrationBuilder
                .Sql("DELETE FROM Users");
        }
    }
}
