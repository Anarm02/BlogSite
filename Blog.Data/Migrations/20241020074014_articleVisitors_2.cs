using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class articleVisitors_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9f1c0f03-5c9a-4eba-8e3e-2677dfd3e7ba"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ed9ae26f-9b38-4761-ba9b-8b942eb5ec8a"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("6dc39e10-e773-4b43-b245-080438f65af1"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 10, 20, 11, 40, 14, 27, DateTimeKind.Local).AddTicks(6176), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"), 15 },
                    { new Guid("c94bb116-08d7-4b8b-aa36-81bc9eb1737b"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 10, 20, 11, 40, 14, 27, DateTimeKind.Local).AddTicks(6183), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"), 14 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"),
                column: "ConcurrencyStamp",
                value: "bfbc1f1f-5c73-4cde-8dab-194fa4fa7059");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"),
                column: "ConcurrencyStamp",
                value: "3e3fcdfc-5521-4a64-83f2-a194eaba716f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebadc1d1-0c46-4391-bac7-4ac5cd689169"),
                column: "ConcurrencyStamp",
                value: "929c7eb5-d43e-4366-aed0-c1660c3d2740");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d30492a-456a-4c25-9556-485719f13980", "AQAAAAEAACcQAAAAEMIIDXcbiZ5ZHp7HAwYiP6qwp5diEStOPAuytBnSwWS7ueJvcaUKDZrWffwbghWS9A==", "3ababda8-2b56-4595-af78-1600adb2f9f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96b3e938-e238-4126-8deb-69f7057ebda8", "AQAAAAEAACcQAAAAEBsRTQaCVtTBqjyHJQobZjBYEAyOQzIjIEq3nrxorK1B9Jz6juy9PpxOO3nPOa1JhQ==", "e52b9a18-ac4d-4479-b006-3a7a0355b0ae" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 40, 14, 27, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 40, 14, 27, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 40, 14, 27, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 40, 14, 27, DateTimeKind.Local).AddTicks(7749));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6dc39e10-e773-4b43-b245-080438f65af1"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c94bb116-08d7-4b8b-aa36-81bc9eb1737b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("9f1c0f03-5c9a-4eba-8e3e-2677dfd3e7ba"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 10, 20, 11, 2, 46, 304, DateTimeKind.Local).AddTicks(2669), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"), 14 },
                    { new Guid("ed9ae26f-9b38-4761-ba9b-8b942eb5ec8a"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 10, 20, 11, 2, 46, 304, DateTimeKind.Local).AddTicks(2659), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"),
                column: "ConcurrencyStamp",
                value: "641b847f-9fd4-434f-9fd1-3d77edcb9379");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"),
                column: "ConcurrencyStamp",
                value: "84fc7cf6-9909-4d6d-90d8-cc2792df4152");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebadc1d1-0c46-4391-bac7-4ac5cd689169"),
                column: "ConcurrencyStamp",
                value: "3d5ef41c-5527-47b5-82ed-07e17ce00b96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "088d6d95-52d3-487e-8dd6-ac95ae30aeef", "AQAAAAEAACcQAAAAEFXGvozRcP1tSO6qTLJUOKjHrjnohPcw4W2KJiCxWSbpOKnup6LCXt6Pzc8dW2TSEw==", "bfa03d2d-e787-42ad-8ce6-e7d63a35aa42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b665dcb3-8793-4859-ac49-29eb4d7c4d70", "AQAAAAEAACcQAAAAECsOnfleHnVcoDp5R+vofpPgqaOoJD9kmkIvURrLUmxnY6qOW4sXpEQ3Lf5zL0oZQg==", "c0f5853d-4bd1-4640-8f6a-4723fc8169a9" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 2, 46, 304, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 2, 46, 304, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 2, 46, 304, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 11, 2, 46, 304, DateTimeKind.Local).AddTicks(4123));
        }
    }
}
