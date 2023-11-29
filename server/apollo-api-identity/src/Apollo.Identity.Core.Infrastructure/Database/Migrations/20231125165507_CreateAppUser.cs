using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apollo.Identity.Core.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "appuser",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    fname = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    lname = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    auth_provider_name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    auth_provider_type = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    auth_provider_user_id = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    auth_provider_user_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    email_verified = table.Column<bool>(type: "bit", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    phone_verified = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    row_version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appuser", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appuser",
                schema: "dbo");
        }
    }
}
