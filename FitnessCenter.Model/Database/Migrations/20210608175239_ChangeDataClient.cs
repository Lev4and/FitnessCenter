using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCenter.Model.Database.Migrations
{
    public partial class ChangeDataClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("1bdbb176-6ae3-4251-858d-4c16023b7ec7"),
                column: "Photo",
                value: "upload/clients/1bdbb176-6ae3-4251-858d-4c16023b7ec7/photo.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("1bdbb176-6ae3-4251-858d-4c16023b7ec7"),
                column: "Photo",
                value: "clients/1bdbb176-6ae3-4251-858d-4c16023b7ec7/photo.jpg");
        }
    }
}
