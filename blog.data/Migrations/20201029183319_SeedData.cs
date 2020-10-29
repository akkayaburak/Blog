using Microsoft.EntityFrameworkCore.Migrations;

namespace blog.data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Ahmet')");
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Alper')");
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Ali')");
            migrationBuilder
                .Sql("INSERT INTO Users (Name) Values ('Veli')");

            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('selamın aleykum', (SELECT Id FROM Users WHERE Name = 'Ali'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('allahın adını verdik', (SELECT Id FROM Users WHERE Name = 'Ali'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('haydalavista', (SELECT Id FROM Users WHERE Name = 'Ali'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('wtf is this?', (SELECT Id FROM Users WHERE Name = 'Veli'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('allaha emanet', (SELECT Id FROM Users WHERE Name = 'Veli'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('see ya', (SELECT Id FROM Users WHERE Name = 'Veli'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('What''s left of the flag', (SELECT Id FROM Users WHERE Name = 'Alper'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('ne diyirsen', (SELECT Id FROM Users WHERE Name = 'Alper'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('If I Ever Leave this World Alive', (SELECT Id FROM Users WHERE Name = 'Alper'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Californication', (SELECT Id FROM Users WHERE Name = 'Ahmet'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Tell Me Baby', (SELECT Id FROM Users WHERE Name = 'Ahmet'))");
            migrationBuilder
                .Sql("INSERT INTO Posts (Context, UserId) Values ('Parallel Universe', (SELECT Id FROM Users WHERE Name = 'Ahmet'))");
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