using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class articleVisitors_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("118857d7-9b0d-49f5-ac8e-a3a595b4a89a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ef128b25-e2bf-4523-b8f8-998d011b6043"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("118857d7-9b0d-49f5-ac8e-a3a595b4a89a"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 10, 20, 10, 55, 11, 689, DateTimeKind.Local).AddTicks(1621), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"), 14 },
                    { new Guid("ef128b25-e2bf-4523-b8f8-998d011b6043"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 10, 20, 10, 55, 11, 689, DateTimeKind.Local).AddTicks(1615), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"),
                column: "ConcurrencyStamp",
                value: "c8f34eea-a8e7-4095-9270-6e7303bce94c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"),
                column: "ConcurrencyStamp",
                value: "94e2f038-da55-4fe0-b973-9d36910b9063");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebadc1d1-0c46-4391-bac7-4ac5cd689169"),
                column: "ConcurrencyStamp",
                value: "6a78cd88-5ee1-4c09-aeb4-6948801c77f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67ff92b0-6e58-47c1-90a2-cab92fed6390", "AQAAAAEAACcQAAAAEK48K7K7huRiJsJnzg6qar9XrTl60Elje5aDrxYI3gNtGVQaLeBG+P7XbM6p1+6W1Q==", "acbc2919-caae-464e-916e-3698875e7615" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d1803d5-f78f-41b0-81ed-eadffd2144fb", "AQAAAAEAACcQAAAAEFu5NOh3zskJOlkmkGGknKDy7ABAAN/7A3BbdjwXcyqwaiuEm3FXQkzt1xAX2DJJeg==", "66db6a6d-6e46-490e-9987-59fe82f41289" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 10, 55, 11, 689, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 10, 55, 11, 689, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 10, 55, 11, 689, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                column: "CreatedDate",
                value: new DateTime(2024, 10, 20, 10, 55, 11, 689, DateTimeKind.Local).AddTicks(3126));
        }
    }
}
