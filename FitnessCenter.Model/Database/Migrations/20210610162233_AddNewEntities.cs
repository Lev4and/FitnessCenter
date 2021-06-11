using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCenter.Model.Database.Migrations
{
    public partial class AddNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequireATrainer",
                table: "Services",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "ClientServices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DaysOfWeek",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfWeek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TrainerId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerServices_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainerSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TrainerId = table.Column<Guid>(nullable: false),
                    DayOfWeekId = table.Column<Guid>(nullable: false),
                    From = table.Column<int>(nullable: false),
                    Until = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerSchedules_DaysOfWeek_DayOfWeekId",
                        column: x => x.DayOfWeekId,
                        principalTable: "DaysOfWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerSchedules_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D2808A4-A723-4072-9110-F6659E3FC6CA",
                column: "ConcurrencyStamp",
                value: "4e463e7e-d90d-44be-a42d-ca21a2823162");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "79160ca0-79aa-4e84-8e25-4204fe5487a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C994C0E3-605D-4661-85E5-A7409D197696",
                column: "ConcurrencyStamp",
                value: "ab1f6411-1bcb-4068-8982-95c002300418");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9aa1107a-6fdb-47f4-aad2-a260c8eb2506", "AQAAAAEAACcQAAAAEEucCWquJcEPAx8e0w3Ggn5IXg9ETWIJPfM388MOaA9HJiGga1ErsAZSqY8Y4a39ZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2207040A-5BC4-4E9B-9B61-3F9ABAC55656",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f3e5403-4cdd-4c87-bf55-31a757b492b2", "AQAAAAEAACcQAAAAEK+42RF8bDwfiTbSXkFPyvzzMXNS2ljfLRkv0xRn+6HH7mm20TL51dTkNtYgqAPHvg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69D4573C-6729-4C41-A7A4-B8640C483F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce94c4bb-a7da-487c-8e5a-f6f0c9efd214", "AQAAAAEAACcQAAAAEDXgKXWW5uOwDby/exr5k/WeX2YosMIyXV+zB3JxbfnqyCRNof501b0+flpNAonjWA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_TrainerId",
                table: "ClientServices",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSchedules_DayOfWeekId",
                table: "TrainerSchedules",
                column: "DayOfWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSchedules_TrainerId",
                table: "TrainerSchedules",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerServices_ServiceId",
                table: "TrainerServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerServices_TrainerId",
                table: "TrainerServices",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientServices_Trainers_TrainerId",
                table: "ClientServices",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientServices_Trainers_TrainerId",
                table: "ClientServices");

            migrationBuilder.DropTable(
                name: "TrainerSchedules");

            migrationBuilder.DropTable(
                name: "TrainerServices");

            migrationBuilder.DropTable(
                name: "DaysOfWeek");

            migrationBuilder.DropIndex(
                name: "IX_ClientServices_TrainerId",
                table: "ClientServices");

            migrationBuilder.DropColumn(
                name: "RequireATrainer",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "ClientServices");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D2808A4-A723-4072-9110-F6659E3FC6CA",
                column: "ConcurrencyStamp",
                value: "8899ff93-6fbb-4972-a813-725cd7b75d02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "c4903dd5-b13a-4a80-95f9-ecacc21b3d9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C994C0E3-605D-4661-85E5-A7409D197696",
                column: "ConcurrencyStamp",
                value: "41f1a17a-62ae-495c-b948-ae3fa68a1e25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "636b06ad-1f83-4829-8b58-76d52201b124", "AQAAAAEAACcQAAAAEDp4mCs+ETrcoewvL16f3+cPH5Hyv9F1ac/3ytoYCUddaCb1QfS0LLIOie5Fj0N/GQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2207040A-5BC4-4E9B-9B61-3F9ABAC55656",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b8d94ad-5bc2-44c3-908d-e8ffd80a67a4", "AQAAAAEAACcQAAAAEMZuKeSUkjrNH4Gq7irDFSuA+bbqknLecGjcGLZ17LLXeTLwby8oByWDk3TJ/lqjOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69D4573C-6729-4C41-A7A4-B8640C483F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad35be68-1b65-442e-9641-4334246aa4a4", "AQAAAAEAACcQAAAAEHQ3w74G4YH4VACUwO/miCZZNNnykrVUkj2DcrIb93OEy9sviP3AxEau+hrYVcXBqw==" });
        }
    }
}
