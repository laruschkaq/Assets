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
                    ParentDeviceGroupId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    LastModifiedOnDateTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroup", x => x.Id);
                    table.CheckConstraint("CK_No_Self_Reference", "1 = case when ParentDeviceGroupId = Id then 0 else 1 end");
                    table.ForeignKey(
                        name: "FK_DeviceGroup_DeviceGroup_ParentDeviceGroupId",
                        column: x => x.ParentDeviceGroupId,
                        principalSchema: "dbo",
                        principalTable: "DeviceGroup",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_DeviceGroup_ParentDeviceGroupId",
                schema: "dbo",
                table: "DeviceGroup",
                column: "ParentDeviceGroupId");
            
            migrationBuilder.InsertData(
                table: "DeviceGroup",
                columns: new[] { "Name", "ParentDeviceGroupId", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Group 1", null, true, "2024-04-02 14:00", "2024-04-02 14:00" });
            
            migrationBuilder.InsertData(
                table: "DeviceGroup",
                columns: new[] { "Name", "ParentDeviceGroupId", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Group 2", null, true, "2024-04-02 14:00", "2024-04-02 14:00" })
                ;
            migrationBuilder.InsertData(
                table: "DeviceGroup",
                columns: new[] { "Name", "ParentDeviceGroupId", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Sub Group 2", 2, true, "2024-04-02 14:00", "2024-04-02 14:00" });
            
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Name", "SerialNumber", "FirmwareVersion", "DeviceGroupId", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Asset", "2165541", "1.0", 1, true, "2024-04-02 14:00", "2024-04-02 14:00" });
            
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Name", "SerialNumber", "FirmwareVersion", "DeviceGroupId", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Asset1", "6549684", "1.0", 2, true, "2024-04-02 14:00", "2024-04-02 14:00" });
            
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Name", "SerialNumber", "FirmwareVersion", "DeviceGroupId", "Active", "CreatedOnDateTime", "LastModifiedOnDateTime" },
                values: new object[] { "Asset2", "1454984", "1.0", 3, true, "2024-04-02 14:00", "2024-04-02 14:00" });
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
