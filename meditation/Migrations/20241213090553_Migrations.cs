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
                    MantraImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    MantraAudioPath = table.Column<string>(type: "TEXT", nullable: true),
                    MantraDescription = table.Column<string>(type: "TEXT", nullable: true),
                    LordImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    LordThreedPath = table.Column<string>(type: "TEXT", nullable: true),
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
