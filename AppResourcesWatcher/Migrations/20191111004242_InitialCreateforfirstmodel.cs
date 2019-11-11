using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppResourcesWatcher.Migrations
{
    public partial class InitialCreateforfirstmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemorySnapshots",
                columns: table => new
                {
                    MemorySnapshotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<int>(nullable: false),
                    Used = table.Column<int>(nullable: false),
                    Free = table.Column<int>(nullable: false),
                    Shared = table.Column<int>(nullable: false),
                    BuffCache = table.Column<int>(nullable: false),
                    Available = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemorySnapshots", x => x.MemorySnapshotId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemorySnapshots");
        }
    }
}
