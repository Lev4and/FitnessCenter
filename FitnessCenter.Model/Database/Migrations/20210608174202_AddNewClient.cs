using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCenter.Model.Database.Migrations
{
    public partial class AddNewClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D2808A4-A723-4072-9110-F6659E3FC6CA",
                column: "ConcurrencyStamp",
                value: "517dc1b8-1d31-4a47-a042-1921e352d98c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "2c6203cd-3259-47a4-9fe4-13b74546145a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C994C0E3-605D-4661-85E5-A7409D197696",
                column: "ConcurrencyStamp",
                value: "7dd92456-ab97-4e87-ae42-e4a283ef24d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f26e1ca-d0e1-40fa-b9f0-f187ad43214b", "AQAAAAEAACcQAAAAEH7xPdckxxZZa0mbEJIlDr9rT3pbQhHcjXSCu/3v1MXjQX2Rw8FHrV1uy8yH5Yj3xA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2207040A-5BC4-4E9B-9B61-3F9ABAC55656",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3791598f-0f14-4e68-97e1-faa929746e22", "AQAAAAEAACcQAAAAEHEtbDqVi3VF5cuKMk5pnIXJNOPTc+myGFlkBpDgmSdLNkwQJTi/Re3pITmBOKRaQA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69D4573C-6729-4C41-A7A4-B8640C483F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "633ac028-b0e4-4202-9394-f55fceecd6a4", "AQAAAAEAACcQAAAAEOclZJVlgwxxPOyCPmyws/qKQ1Fvihb3DlbJjOotyhdU0K7Jb1c27TAZaBjxojVXxA==" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "GenderId", "LastName", "MiddleName", "Photo", "UserId" },
                values: new object[] { new Guid("1bdbb176-6ae3-4251-858d-4c16023b7ec7"), new DateTime(1995, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Екатерина", new Guid("4ffae81a-91f9-4092-910e-b79b6090b753"), "Макеева", "Александровна", "clients/1bdbb176-6ae3-4251-858d-4c16023b7ec7/photo.jpg", new Guid("69d4573c-6729-4c41-a7a4-b8640c483f5f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("1bdbb176-6ae3-4251-858d-4c16023b7ec7"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D2808A4-A723-4072-9110-F6659E3FC6CA",
                column: "ConcurrencyStamp",
                value: "bd414f0e-2248-4051-8847-a3277785a06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "9adf7004-ccec-44e1-ad9b-f52c21c1e306");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C994C0E3-605D-4661-85E5-A7409D197696",
                column: "ConcurrencyStamp",
                value: "27ae13ed-0849-465c-a1ae-d619bf630dc2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6c54351-fce4-464d-b60d-2887f5f6c7c2", "AQAAAAEAACcQAAAAEEnRGkokIR4E8w3F4w4QJW18bYwWb30FYWLaznzr8dLMYB9MUM4u5f5IVql1/lTzrA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2207040A-5BC4-4E9B-9B61-3F9ABAC55656",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f14781b4-af66-4fb3-8511-a3a0a73ec673", "AQAAAAEAACcQAAAAEPyb5iPOh0Bz+eJm7YaNh52wf5DdwyXUvP1PhSmqfBks49o03UFh/iluTUI1WIR2AQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69D4573C-6729-4C41-A7A4-B8640C483F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "011332b1-4f01-4cbf-a9a0-9d0817b423e5", "AQAAAAEAACcQAAAAEKTBKYSIwDqsRCrj3ZSbIRjuuLMcNzi78R1owOW2HGL6ckrVO70Ne+SBv/Vb/WGjIw==" });
        }
    }
}
