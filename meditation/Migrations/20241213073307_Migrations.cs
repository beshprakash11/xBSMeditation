﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meditation.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mantras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MantraName = table.Column<string>(type: "TEXT", nullable: false),
                    MantraImage = table.Column<string>(type: "TEXT", nullable: false),
                    MantraAudio = table.Column<string>(type: "TEXT", nullable: false),
                    MantraDescription = table.Column<string>(type: "TEXT", nullable: false),
                    LordImage = table.Column<string>(type: "TEXT", nullable: false),
                    LordThreed = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantras", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantras");
        }
    }
}
