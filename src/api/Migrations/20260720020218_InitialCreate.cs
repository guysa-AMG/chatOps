using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace chatOps.api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    author = table.Column<string>(type: "text", nullable: false),
                    tags = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    links = table.Column<string[]>(type: "text[]", nullable: false),
                    BackgroundImage = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: true),
                    SecondaryEmail = table.Column<string>(type: "text", nullable: false),
                    roomId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Rooms_roomId",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId");
                });

            migrationBuilder.CreateTable(
                name: "RoomUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roomId = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    joinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomUser_Rooms_roomId",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomUser_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_roomId",
                table: "RoomUser",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_userId",
                table: "RoomUser",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roomId",
                table: "Users",
                column: "roomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomUser");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
