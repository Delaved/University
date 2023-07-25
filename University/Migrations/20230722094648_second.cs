﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Record");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Record",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
