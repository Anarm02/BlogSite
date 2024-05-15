using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
    public partial class UserCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8b218589-4441-4c54-8b62-08c2edff4136"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9598110c-8527-4c64-83c2-a5ff2c9b48da"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2ec40ba4-d347-4317-96c1-2093c9c4f816"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 15, 20, 45, 32, 113, DateTimeKind.Local).AddTicks(827), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", 14 },
                    { new Guid("36e21123-d2c0-4a4d-b683-cd4c7ce5f468"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 15, 20, 45, 32, 113, DateTimeKind.Local).AddTicks(819), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"), "f0fd3f5a-241d-4ed4-af9d-b4e4c91b0e0f", "Superadmin", "SUPERADMIN" },
                    { new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"), "b215f8c4-3739-47cd-8d31-4051391bdd67", "Admin", "ADMIN" },
                    { new Guid("ebadc1d1-0c46-4391-bac7-4ac5cd689169"), "497b3342-f2f6-4d3e-9df9-516f0871cae0", "User", "NAME" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("60f812e7-9374-4623-873b-c28d9f6437e4"), 0, "b31c54b2-e072-4074-9ff8-6e91fb682049", "superadmin@gmail.com", true, "Anar", "Mammadli", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEP/tQrCKx3FjCriSWZkBsDRmV51hJECUM9RlDNZJGAGHxede/4CdAAb/CIgDKBoOsg==", "+9940506983552", true, "1ccadcfc-0c58-4e0d-8fbf-6820e7b5b9f4", false, "superadmin@gmail.com" },
                    { new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2"), 0, "9b2f6580-facf-4655-bfe8-101d04f2d426", "admin@gmail.com", false, "Anr", "Mammdli", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENr4hs4CKppmSyeh2mzZMtY0SFvAZJzLi0noy22IlaUZZYtVatD8jT8T2EJf1/rPiQ==", "+9940506983542", false, "549284d3-0705-4a4e-832e-cef7ee2e9f37", false, "admin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 20, 45, 32, 113, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 20, 45, 32, 113, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 20, 45, 32, 113, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 20, 45, 32, 113, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("174152d8-e285-42ed-ac05-8d41dae118c4"), new Guid("60f812e7-9374-4623-873b-c28d9f6437e4") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("22428d23-2ce0-4d33-8b57-82a2c649ab04"), new Guid("fa2cc9c4-4293-4a01-95cd-f67a85a744d2") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2ec40ba4-d347-4317-96c1-2093c9c4f816"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("36e21123-d2c0-4a4d-b683-cd4c7ce5f468"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8b218589-4441-4c54-8b62-08c2edff4136"), new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"), " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 9, 21, 52, 21, 753, DateTimeKind.Local).AddTicks(3167), null, null, new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"), false, null, null, "Visual Studio Article 1", 14 },
                    { new Guid("9598110c-8527-4c64-83c2-a5ff2c9b48da"), new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.", "Admin Test", new DateTime(2024, 5, 9, 21, 52, 21, 753, DateTimeKind.Local).AddTicks(3149), null, null, new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"), false, null, null, "Asp.net Core Article 1", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e35e8b13-c92f-4720-bb44-bd0536925b08"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 52, 21, 753, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f77fc9bc-b838-4745-93bf-17564a78dfc9"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 52, 21, 753, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3a94e829-4a63-4598-8bd7-80aeda1eef6a"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 52, 21, 753, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7de25a1b-6c11-4aa3-9974-172c52571b2e"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 9, 21, 52, 21, 753, DateTimeKind.Local).AddTicks(4877));
        }
    }
}
