using Microsoft.EntityFrameworkCore.Migrations;

namespace WoMakersCode.Biblioteca.Infra.Migrations
{
    public partial class InsertUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO usuarios(nome, endereco, telefone) values ('Jamile', 'Rua x', '55555');");
            migrationBuilder.Sql("INSERT INTO usuarios(nome, endereco, telefone) values ('Jessica', 'Rua y', '55556');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
