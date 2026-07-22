using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace chatOps.api.Migrations
{
    /// <inheritdoc />
    public partial class changedTagged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomUser_Rooms_roomId",
                table: "RoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomUser_Users_userId",
                table: "RoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomUser",
                table: "RoomUser");

            migrationBuilder.DropColumn(
                name: "tags",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "RoomUser",
                newName: "room_user");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "users",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "users",
                newName: "room_id");

            migrationBuilder.RenameColumn(
                name: "SecondaryEmail",
                table: "users",
                newName: "secondary_email");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "BackgroundImage",
                table: "users",
                newName: "background_image");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roomId",
                table: "users",
                newName: "ix_users_room_id");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "rooms",
                newName: "room_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "room_user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "room_user",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "room_user",
                newName: "room_id");

            migrationBuilder.RenameColumn(
                name: "joinedAt",
                table: "room_user",
                newName: "joined_at");

            migrationBuilder.RenameIndex(
                name: "IX_RoomUser_userId",
                table: "room_user",
                newName: "ix_room_user_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_RoomUser_roomId",
                table: "room_user",
                newName: "ix_room_user_room_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "rooms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "creator",
                table: "rooms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rooms",
                table: "rooms",
                column: "room_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_room_user",
                table: "room_user",
                column: "id");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    colour = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room_tag",
                columns: table => new
                {
                    roomsroom_id = table.Column<int>(type: "integer", nullable: false),
                    tags_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room_tag", x => new { x.roomsroom_id, x.tags_id });
                    table.ForeignKey(
                        name: "fk_room_tag_rooms_roomsroom_id",
                        column: x => x.roomsroom_id,
                        principalTable: "rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_room_tag_tags_tags_id",
                        column: x => x.tags_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_room_tag_tags_id",
                table: "room_tag",
                column: "tags_id");

            migrationBuilder.AddForeignKey(
                name: "fk_room_user_rooms_room_id",
                table: "room_user",
                column: "room_id",
                principalTable: "rooms",
                principalColumn: "room_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_room_user_users_user_id",
                table: "room_user",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_users_rooms_room_id",
                table: "users",
                column: "room_id",
                principalTable: "rooms",
                principalColumn: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_room_user_rooms_room_id",
                table: "room_user");

            migrationBuilder.DropForeignKey(
                name: "fk_room_user_users_user_id",
                table: "room_user");

            migrationBuilder.DropForeignKey(
                name: "fk_users_rooms_room_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "room_tag");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "pk_room_user",
                table: "room_user");

            migrationBuilder.DropColumn(
                name: "created",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "creator",
                table: "rooms");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "room_user",
                newName: "RoomUser");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Users",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "secondary_email",
                table: "Users",
                newName: "SecondaryEmail");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "Users",
                newName: "roomId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "background_image",
                table: "Users",
                newName: "BackgroundImage");

            migrationBuilder.RenameIndex(
                name: "ix_users_room_id",
                table: "Users",
                newName: "IX_Users_roomId");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "Rooms",
                newName: "roomId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RoomUser",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "RoomUser",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "RoomUser",
                newName: "roomId");

            migrationBuilder.RenameColumn(
                name: "joined_at",
                table: "RoomUser",
                newName: "joinedAt");

            migrationBuilder.RenameIndex(
                name: "ix_room_user_user_id",
                table: "RoomUser",
                newName: "IX_RoomUser_userId");

            migrationBuilder.RenameIndex(
                name: "ix_room_user_room_id",
                table: "RoomUser",
                newName: "IX_RoomUser_roomId");

            migrationBuilder.AddColumn<int[]>(
                name: "tags",
                table: "Rooms",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "roomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomUser",
                table: "RoomUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUser_Rooms_roomId",
                table: "RoomUser",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "roomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUser_Users_userId",
                table: "RoomUser",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_roomId",
                table: "Users",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "roomId");
        }
    }
}
