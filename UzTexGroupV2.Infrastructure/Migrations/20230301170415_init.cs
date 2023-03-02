using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UzTexGroupV2.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => new { x.Id, x.LanguageCode });
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => new { x.Id, x.LanguageCode });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiredRefreshToken = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => new { x.Id, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_Factory_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factory_Company_CompanyId_LanguageCode",
                        columns: x => new { x.CompanyId, x.LanguageCode },
                        principalTable: "Company",
                        principalColumns: new[] { "Id", "LanguageCode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FactoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => new { x.Id, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_Job_Factory_FactoryId_LanguageCode",
                        columns: x => new { x.FactoryId, x.LanguageCode },
                        principalTable: "Factory",
                        principalColumns: new[] { "Id", "LanguageCode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationMessage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Job_JobId_LanguageCode",
                        columns: x => new { x.JobId, x.LanguageCode },
                        principalTable: "Job",
                        principalColumns: new[] { "Id", "LanguageCode" });
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("9c6007cb-635f-4db1-932c-b4419141041a"), "uz", "Uzbek" },
                    { new Guid("e0f77cf9-6614-4929-9e58-7aaed7d939c9"), "ru", "Russian" },
                    { new Guid("e619238b-c2ad-420f-a7fe-7a2a95ca567a"), "en", "English" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "ExpiredRefreshToken", "FirstName", "LastName", "PasswordHash", "RefreshToken", "Salt", "UserRole" },
                values: new object[] { new Guid("1cf67e1b-18bb-417c-9fd2-78baa150f9a2"), "elchinuralov07@gmail.com", null, "Elchin", "Uralov", "v7DrXBP/nQ3sHmWUgp6nkmBkJCeKxVK4+iljRqJfgDI=", null, "a9feaa2d-8692-4d2e-bf64-3d8200ad8c8b", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AddressId",
                table: "Applications",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId_LanguageCode",
                table: "Applications",
                columns: new[] { "JobId", "LanguageCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Factory_AddressId",
                table: "Factory",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factory_CompanyId_LanguageCode",
                table: "Factory",
                columns: new[] { "CompanyId", "LanguageCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_FactoryId_LanguageCode",
                table: "Job",
                columns: new[] { "FactoryId", "LanguageCode" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Factory");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
