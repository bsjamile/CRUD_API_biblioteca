using Microsoft.EntityFrameworkCore.Migrations;

namespace WoMakersCode.Biblioteca.Infra.Migrations
{
    public partial class AddAutores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.Id);
                });

            migrationBuilder.Sql("insert into autores(nome) values ('Autor 1');");
            migrationBuilder.Sql("insert into autores(nome) values ('Autor 2');");
            migrationBuilder.Sql("insert into autores(nome) values ('Autor 3');");
            migrationBuilder.Sql("insert into autores(nome) values ('Autor 4');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autores");
        }
    }
}
