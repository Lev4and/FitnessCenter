using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCenter.Model.Database.Migrations
{
    public partial class AddNewUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2207040A-5BC4-4E9B-9B61-3F9ABAC55656", 0, "f14781b4-af66-4fb3-8511-a3a0a73ec673", "manager@gmail.com", true, false, null, "MANAGER@GMAIL.COM", "MANAGER", "AQAAAAEAACcQAAAAEPyb5iPOh0Bz+eJm7YaNh52wf5DdwyXUvP1PhSmqfBks49o03UFh/iluTUI1WIR2AQ==", null, false, "", false, "Manager" },
                    { "69D4573C-6729-4C41-A7A4-B8640C483F5F", 0, "011332b1-4f01-4cbf-a9a0-9d0817b423e5", "client@gmail.com", true, false, null, "CLIENT@GMAIL.COM", "CLIENT", "AQAAAAEAACcQAAAAEKTBKYSIwDqsRCrj3ZSbIRjuuLMcNzi78R1owOW2HGL6ckrVO70Ne+SBv/Vb/WGjIw==", null, false, "", false, "Client" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2207040A-5BC4-4E9B-9B61-3F9ABAC55656", "C994C0E3-605D-4661-85E5-A7409D197696" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "69D4573C-6729-4C41-A7A4-B8640C483F5F", "3D2808A4-A723-4072-9110-F6659E3FC6CA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2207040A-5BC4-4E9B-9B61-3F9ABAC55656", "C994C0E3-605D-4661-85E5-A7409D197696" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "69D4573C-6729-4C41-A7A4-B8640C483F5F", "3D2808A4-A723-4072-9110-F6659E3FC6CA" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2207040A-5BC4-4E9B-9B61-3F9ABAC55656");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "69D4573C-6729-4C41-A7A4-B8640C483F5F");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D2808A4-A723-4072-9110-F6659E3FC6CA",
                column: "ConcurrencyStamp",
                value: "496a7113-8746-409b-8b61-ef2e9341580a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "650087d3-bea9-4f95-8f2c-414a40079966");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C994C0E3-605D-4661-85E5-A7409D197696",
                column: "ConcurrencyStamp",
                value: "7ed84e58-acd8-41f6-a21a-f9b866aad3e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12bcd5fa-84f4-4fe1-b85f-35055c9671f1", "AQAAAAEAACcQAAAAEKdmhxdenhzUasdyzzqsJnAA1jlGsEDPbay4iIrohyInlPwfKmzF7PY65L5NlDJVVA==" });
        }
    }
}
