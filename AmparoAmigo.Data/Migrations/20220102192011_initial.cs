using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmparoAmigo.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TelefoneCelular = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    TipoServico1 = table.Column<string>(type: "TEXT", nullable: true),
                    TipoServico2 = table.Column<string>(type: "TEXT", nullable: true),
                    TipoServico3 = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria1 = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria2 = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: true),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: true),
                    TelefoneCelular = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Responsavel = table.Column<string>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VoluntarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacoes_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    VoluntarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Voluntarios_VoluntarioId",
                        column: x => x.VoluntarioId,
                        principalTable: "Voluntarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Voluntarios",
                columns: new[] { "Id", "Categoria1", "Categoria2", "Categoria3", "Cidade", "DataNascimento", "Descricao", "Endereco", "Estado", "NomeCompleto", "TelefoneCelular", "TipoServico1", "TipoServico2", "TipoServico3" },
                values: new object[] { 1, "Educação", null, null, "São Paulo", new DateTime(1996, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leciono a 10 anos", "Rua 1", "SP", "Lucas Batista", "(11) 98763-6567", "Professor", null, null });

            migrationBuilder.InsertData(
                table: "Voluntarios",
                columns: new[] { "Id", "Categoria1", "Categoria2", "Categoria3", "Cidade", "DataNascimento", "Descricao", "Endereco", "Estado", "NomeCompleto", "TelefoneCelular", "TipoServico1", "TipoServico2", "TipoServico3" },
                values: new object[] { 2, "Geral", null, null, "Rio de Janeiro", new DateTime(1998, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quero Ajudar", "Rua 2", "RJ", "Leonardo Lopes", "(11) 98763-6567", "Ajudante Geral", null, null });

            migrationBuilder.InsertData(
                table: "Voluntarios",
                columns: new[] { "Id", "Categoria1", "Categoria2", "Categoria3", "Cidade", "DataNascimento", "Descricao", "Endereco", "Estado", "NomeCompleto", "TelefoneCelular", "TipoServico1", "TipoServico2", "TipoServico3" },
                values: new object[] { 3, "Comunicação", null, null, "Governador Valadares", new DateTime(1986, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leciono a 10 anos", "Rua 3", "MG", "Diego Grava", "(11) 98763-6567", "Professor Artes", null, null });

            migrationBuilder.InsertData(
                table: "Voluntarios",
                columns: new[] { "Id", "Categoria1", "Categoria2", "Categoria3", "Cidade", "DataNascimento", "Descricao", "Endereco", "Estado", "NomeCompleto", "TelefoneCelular", "TipoServico1", "TipoServico2", "TipoServico3" },
                values: new object[] { 4, "serviços Gerais", null, null, "Acrelândia", new DateTime(1998, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ensino musica", "Rua 4", "AC", "Igor Kimura", "(11) 98763-6567", "Rapper", null, null });

            migrationBuilder.InsertData(
                table: "Voluntarios",
                columns: new[] { "Id", "Categoria1", "Categoria2", "Categoria3", "Cidade", "DataNascimento", "Descricao", "Endereco", "Estado", "NomeCompleto", "TelefoneCelular", "TipoServico1", "TipoServico2", "TipoServico3" },
                values: new object[] { 5, "Saúde", null, null, "Florianópolis", new DateTime(1976, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sou Enfermeiro a 10 anos", "Rua 5", "SC", "Fabricio Antunes", "(11) 98763-6567", "Enfermeiro", null, null });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha", "VoluntarioId" },
                values: new object[] { 1, "LucasBatista@gmail.com", "Teste123", 1 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha", "VoluntarioId" },
                values: new object[] { 2, "LeonardoLopez@gmail.com", "Teste123", 2 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha", "VoluntarioId" },
                values: new object[] { 3, "DiegoGrava@gmail.com", "Teste123", 3 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha", "VoluntarioId" },
                values: new object[] { 4, "IgorKimura@gmail.com", "Teste123", 4 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Senha", "VoluntarioId" },
                values: new object[] { 5, "FabricioAntunes@gmail.com", "Teste123", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacoes_VoluntarioId",
                table: "Solicitacoes",
                column: "VoluntarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_VoluntarioId",
                table: "Usuarios",
                column: "VoluntarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Voluntarios");
        }
    }
}
