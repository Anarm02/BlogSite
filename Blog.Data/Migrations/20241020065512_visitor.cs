using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class visitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("07104c6d-34fa-4c65-b413-4db2b579da80"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7382c525-b33b-4df4-b5c9-e7abd4cc1c7f"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

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
                    { new Guid("07104c6d-34fa-4c65-b413-4db2b579da80"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 16, 12, 56, 7, 739, DateTimeKind.Local).AddTicks(3995), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"), 15 },
                    { new Guid("7382c525-b33b-4df4-b5c9-e7abd4cc1c7f"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 16, 12, 56, 7, 739, DateTimeKind.Local).AddTicks(4002), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"), 14 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"),
                column: "ConcurrencyStamp",
                value: "1265e089-b1d8-45f1-b652-2dcc004d3754");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"),
                column: "ConcurrencyStamp",
                value: "1effa228-8d6a-4329-a106-d7feb45c3347");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebadc1d1-0c46-4391-bac7-4ac5cd689169"),
                column: "ConcurrencyStamp",
                value: "33b237bb-be83-46b7-9c2d-f359e4dad25a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b30cc90-e3eb-4f85-96d1-4ba3ad1c8f1c", "AQAAAAEAACcQAAAAEO/hsk21QMkhv95VjWAuJrPidZqqWaIH7f0IaLG7oLD9eC64xlE3nh5G3D51eYwE8w==", "78cbcf66-00fd-4c6e-aa03-153013ebbd07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b359714-2563-4498-acc2-e7d2740e1a45", "AQAAAAEAACcQAAAAEJhmPTBlKcD3URGrVLeymM0nGoomshGSJFfcCDhs9J1J6ajCPd8YkSbA59tXrRxCvg==", "112c9879-8551-40e1-a754-0575f1585968" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 12, 56, 7, 739, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 12, 56, 7, 739, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 12, 56, 7, 739, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 16, 12, 56, 7, 739, DateTimeKind.Local).AddTicks(4670));
        }
    }
}
