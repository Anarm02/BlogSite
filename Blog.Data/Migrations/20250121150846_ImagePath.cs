using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class ImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6dc39e10-e773-4b43-b245-080438f65af1"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c94bb116-08d7-4b8b-aa36-81bc9eb1737b"));

            migrationBuilder.AddColumn<string>(
                name: "FullPath",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("51da58b8-9bb8-4443-9167-b1caa26b74ed"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2025, 1, 21, 19, 8, 45, 681, DateTimeKind.Local).AddTicks(9097), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"), 15 },
                    { new Guid("b79bdee5-af92-4512-8fb7-233974a97289"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2025, 1, 21, 19, 8, 45, 681, DateTimeKind.Local).AddTicks(9114), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"), 14 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"),
                column: "ConcurrencyStamp",
                value: "bea2df68-ebc3-43b3-be13-31a8900bd56c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"),
                column: "ConcurrencyStamp",
                value: "576b079a-5624-4f0f-9844-269e7c7c403c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebadc1d1-0c46-4391-bac7-4ac5cd689169"),
                column: "ConcurrencyStamp",
                value: "671c43ef-5a11-4536-ba22-b10b48e65325");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b444669-57f9-463f-81e0-91eab8eb236e", "AQAAAAEAACcQAAAAEEfpiKSBFEiVP5ahQPel7TTom0PYW0kuJ4azpR3Wcj2878GkRWbeQNGVOhZXqSFh+Q==", "ae3568ae-c209-445b-8af8-b344f67a4d06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da9aac94-ae3d-413c-b039-581cfe643b0d", "AQAAAAEAACcQAAAAEKSYjWrONtwxKebUJZIf4oIpZB0XRKNA7W6H9fzOzU0ODrMN8nV7H8xOjlIFxq6RDA==", "5ee724e7-d522-477b-9221-954b300fd773" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 21, 19, 8, 45, 682, DateTimeKind.Local).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2025, 1, 21, 19, 8, 45, 682, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                columns: new[] { "CreatedDate", "FullPath" },
                values: new object[] { new DateTime(2025, 1, 21, 19, 8, 45, 682, DateTimeKind.Local).AddTicks(3134), "D:\\Backend\\Projects\\BlogSite\\Blog.Web\\wwwroot\\images\\article-images\\gerwgnerjgnerwnkg_814.png" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                columns: new[] { "CreatedDate", "FullPath" },
                values: new object[] { new DateTime(2025, 1, 21, 19, 8, 45, 682, DateTimeKind.Local).AddTicks(3046), "D:\\Backend\\Projects\\BlogSite\\Blog.Web\\wwwroot\\images\\article-images\\efjfnerjnewefef_899.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("51da58b8-9bb8-4443-9167-b1caa26b74ed"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b79bdee5-af92-4512-8fb7-233974a97289"));

            migrationBuilder.DropColumn(
                name: "FullPath",
                table: "Images");

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
    }
}
