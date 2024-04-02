using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceGroup",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    LastModifiedOnDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DeviceGroupId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    LastModifiedOnDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_DeviceGroup_DeviceGroupId",
                        column: x => x.DeviceGroupId,
                        principalSchema: "dbo",
                        principalTable: "DeviceGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_DeviceGroupId",
                schema: "dbo",
                table: "Assets",
                column: "DeviceGroupId");
            
            migrationBuilder.InsertData(
                table: "DeviceGroup",
                columns: new[] { "Name", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Group 1",true,"2024/04/03 09:00","2024/04/03 09:00" });
            
            migrationBuilder.InsertData(
                table: "DeviceGroup",
                columns: new[] { "Name", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Group 2",true,"2024/04/03 09:00","2024/04/03 09:00" });
            

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Name", "SerialNumber", "FirmwareVersion", "DeviceGroupId", "Active", "CreatedOnDateTime","LastModifiedOnDateTime" },
                values: new object[] { "Asset1", "214968498", "1.0", 1, true, "2024/04/03 09:00", "2024/04/03 09:00" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Name", "SerialNumber", "FirmwareVersion", "DeviceGroupId", "Active", "CreatedOnDateTime","LastModifiedOnDateTime"  },
                values: new object[] {  "Asset2", "231987984", "2.0", 2,true, "2024/04/03 09:00", "2024/04/03 09:00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DeviceGroup",
                schema: "dbo");
        }
    }
}
