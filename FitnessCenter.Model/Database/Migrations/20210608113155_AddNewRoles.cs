using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCenter.Model.Database.Migrations
{
    public partial class AddNewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "650087d3-bea9-4f95-8f2c-414a40079966");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3D2808A4-A723-4072-9110-F6659E3FC6CA", "496a7113-8746-409b-8b61-ef2e9341580a", "Клиент", "КЛИЕНТ" },
                    { "C994C0E3-605D-4661-85E5-A7409D197696", "7ed84e58-acd8-41f6-a21a-f9b866aad3e7", "Менеджер", "МЕНЕДЖЕР" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12bcd5fa-84f4-4fe1-b85f-35055c9671f1", "AQAAAAEAACcQAAAAEKdmhxdenhzUasdyzzqsJnAA1jlGsEDPbay4iIrohyInlPwfKmzF7PY65L5NlDJVVA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D2808A4-A723-4072-9110-F6659E3FC6CA");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C994C0E3-605D-4661-85E5-A7409D197696");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "0562c701-8fde-4252-acee-c6e8792258dc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6f48637-25d2-44e8-8303-74d765334ae9", "AQAAAAEAACcQAAAAED52SAwxPpjOYUBV1Ba8EmBtVg7mHnvyZtJ4RehKzF03rxRmyFy1yoUTHaTVxJEmqg==" });
        }
    }
}
