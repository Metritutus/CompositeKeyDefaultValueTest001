using Microsoft.EntityFrameworkCore.Migrations;

namespace CompositeKeyDefaultValueTest001.Migrations
{
    public partial class CompositeKeyDefaultValueTest001v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Something",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Something", x => x.Id);
                    table.UniqueConstraint("AK_Something_Id_CategoryId", x => new { x.Id, x.CategoryId });
                    table.ForeignKey(
                        name: "FK__Something_CategoryId_To_Category_Id",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SomethingOfCategoryA",
                columns: table => new
                {
                    SomethingId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomethingOfCategoryA", x => new { x.SomethingId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK__SomethingOfCategoryA_CategoryId_To_Category_Id",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__SomethingOfCategoryA_SomethingId_CategoryId_To_Something_Id_CategoryId",
                        columns: x => new { x.SomethingId, x.CategoryId },
                        principalTable: "Something",
                        principalColumns: new[] { "Id", "CategoryId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SomethingOfCategoryB",
                columns: table => new
                {
                    SomethingId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 2),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomethingOfCategoryB", x => new { x.SomethingId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK__SomethingOfCategoryB_CategoryId_To_Category_Id",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__SomethingOfCategoryB_SomethingId_CategoryId_To_Something_Id_CategoryId",
                        columns: x => new { x.SomethingId, x.CategoryId },
                        principalTable: "Something",
                        principalColumns: new[] { "Id", "CategoryId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "A" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "B" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "C" });

            migrationBuilder.CreateIndex(
                name: "IX_Something_CategoryId",
                table: "Something",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SomethingOfCategoryA_CategoryId",
                table: "SomethingOfCategoryA",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SomethingOfCategoryB_CategoryId",
                table: "SomethingOfCategoryB",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SomethingOfCategoryA");

            migrationBuilder.DropTable(
                name: "SomethingOfCategoryB");

            migrationBuilder.DropTable(
                name: "Something");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
