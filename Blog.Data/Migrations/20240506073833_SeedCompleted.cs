using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class SeedCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), "Admin Test", new DateTime(2024, 5, 6, 11, 38, 32, 994, DateTimeKind.Local).AddTicks(9462), null, null, false, null, null, "Visual Studio 2022" },
                    { new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Admin Test", new DateTime(2024, 5, 6, 11, 38, 32, 994, DateTimeKind.Local).AddTicks(9458), null, null, false, null, null, "Asp.net Core" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), "Admin Test", new DateTime(2024, 5, 6, 11, 38, 32, 994, DateTimeKind.Local).AddTicks(9644), null, null, "images/VsImage", "png", false, null, null },
                    { new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), "Admin Test", new DateTime(2024, 5, 6, 11, 38, 32, 994, DateTimeKind.Local).AddTicks(9639), null, null, "images/testImage", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("429c3518-7d8d-43b5-b4ad-a81c34dee247"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 6, 11, 38, 32, 994, DateTimeKind.Local).AddTicks(9079), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", 14 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("5163ca57-7011-4e76-8ebb-8205f3cddd1a"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 6, 11, 38, 32, 994, DateTimeKind.Local).AddTicks(9070), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("429c3518-7d8d-43b5-b4ad-a81c34dee247"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5163ca57-7011-4e76-8ebb-8205f3cddd1a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"));
        }
    }
}
