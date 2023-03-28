using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HousekeeperApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Housekeepers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housekeepers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Housekeepers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    Budget = table.Column<double>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    HousekeeperId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Housekeepers_HousekeeperId",
                        column: x => x.HousekeeperId,
                        principalTable: "Housekeepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60", "d65dfe88-64f0-460f-8eb5-09aa7826c1e8", "Client", "Client" },
                    { "92d8da87-ed58-47ff-b3b3-3e8348d8a956", "0b58d8c3-ff77-45e7-9775-87f427096553", "Housekeeper", "Housekeeper" },
                    { "4da8d4c7-fa79-4f7a-b000-19eda97127db", "dc5a3556-be23-4994-9c39-9f426bca2ef9", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05218c2d-5f75-432f-ad79-026caa146ef8", 0, "d316d9a3-9163-4414-8af5-4208bd588e30", "client96@abv.bg", false, "John", "Johnson", false, null, "client96@abv.bg", "client96@abv.bg", "AQAAAAEAACcQAAAAEMA01MZwndKEPjBi0aYpmerOHtj6PSfqNFCPTxuC6651afFgiQtbH6vRWtmnviYT0A==", null, false, "", false, "client96@abv.bg" },
                    { "cf80f72e-9a31-4bd8-b16d-67516dacaa3b", 0, "635e0556-ca8d-44c3-bdc6-72f67ddff72b", "client97@abv.bg", false, "John", "Alexandrov", false, null, "client97@abv.bg", "client97@abv.bg", "AQAAAAEAACcQAAAAEBJRbth7VQLcdFRI1ov86xunN2bX55eWqxNPq2fe+2QEye0hQYDw36EHVGwfp/9EgA==", null, false, "", false, "client97@abv.bg" },
                    { "dca26712-f4c7-440a-85bf-7aa0adba523a", 0, "4d9ff523-f54e-41b6-8338-7b4644da7a7c", "client98@abv.bg", false, "Jack", "Alexandrov", false, null, "client98@abv.bg", "client98@abv.bg", "AQAAAAEAACcQAAAAEGH3PjgaasfmpLaDnu/bmSMavx8T7SLPgMygieVxmPECM4oZRdfNgBaAlsT+y+DxTA==", null, false, "", false, "client98@abv.bg" },
                    { "4cf07cd3-f413-4406-9794-256bd1c8e429", 0, "4c5d514f-f143-4e91-99c0-61cdf2249ba5", "client99@abv.bg", false, "Jane", "Johnson", false, null, "client99@abv.bg", "client99@abv.bg", "AQAAAAEAACcQAAAAEBbhaFwmXNwBlE+utr/nYzFG0gScicjQU+kYY+NyzZOefCBX9EhQHY0QsBZkDJQ2Nw==", null, false, "", false, "client99@abv.bg" },
                    { "a46a5db1-98cf-48b8-821f-1ab8ca82d410", 0, "68ffc687-be9d-403a-b2c2-5c1a068a39b4", "housekeeper0@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper0@abv.bg", "housekeeper0@abv.bg", "AQAAAAEAACcQAAAAEOGcKzjRj1q99ap5YnZV6YlUj4lE50pXzEsUKyb4oNBET6PstHbP08s+p0FlA1fXmw==", null, false, "", false, "housekeeper0@abv.bg" },
                    { "2261ba61-97df-41f8-80b4-25cec5383a94", 0, "06f0b9b5-b5d4-41a0-a85b-ec75d333e641", "housekeeper1@abv.bg", false, "John", "Johnson", false, null, "housekeeper1@abv.bg", "housekeeper1@abv.bg", "AQAAAAEAACcQAAAAEE/B5y2kL3wfjWOPhKct4guWtjXqP7vItskNfvB9ZpnSFHOd7aGGBZlGxhmPcrJ+qQ==", null, false, "", false, "housekeeper1@abv.bg" },
                    { "69b8b5cf-dc0f-4e15-8c30-d2937070c1cb", 0, "301be285-bf94-4332-9014-aa9ba4dc6eb0", "housekeeper2@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper2@abv.bg", "housekeeper2@abv.bg", "AQAAAAEAACcQAAAAEF7ueI7oynbJvE2o10mbZNycX74NuN+RzDI/CmMzP+RWQR/Z1eQwScv04D7QAO5fww==", null, false, "", false, "housekeeper2@abv.bg" },
                    { "caaaba6b-317a-4d0f-9052-06232b8fd021", 0, "63e63fd1-f59a-4245-8c19-170a306a1a73", "housekeeper3@abv.bg", false, "Alex", "Johnson", false, null, "housekeeper3@abv.bg", "housekeeper3@abv.bg", "AQAAAAEAACcQAAAAEBQNiIKl5oq5Bh3Wmzz8ZDT/dDqRDaQ5es3OBaB0gQgTqpAwjl3IqOPbQkYlh+li6g==", null, false, "", false, "housekeeper3@abv.bg" },
                    { "4fa46d5d-9967-4900-b55e-de197a550347", 0, "ef7f9b23-9485-429d-9174-bce918162ade", "housekeeper4@abv.bg", false, "Alex", "Alexandrov", false, null, "housekeeper4@abv.bg", "housekeeper4@abv.bg", "AQAAAAEAACcQAAAAENaYjxi7Zs8T/bTUTstd8ellCj1rlkk6HrtWcCWSoxjPeTZCqBNQbmHs60PznSdPCA==", null, false, "", false, "housekeeper4@abv.bg" },
                    { "ae9ed5b4-9107-4423-b0f3-474a7973325c", 0, "67383494-11af-4e90-998c-606baadb5e7e", "housekeeper5@abv.bg", false, "Alex", "Johnson", false, null, "housekeeper5@abv.bg", "housekeeper5@abv.bg", "AQAAAAEAACcQAAAAEDoIVkImKAKh5pe8suD6TMPp9z34CCkcBvjbtt2vFTORyYA1MyBQfkIFY/GsfDSwww==", null, false, "", false, "housekeeper5@abv.bg" },
                    { "891ab165-1375-407d-b89c-8c65d9e71901", 0, "35714946-e069-4fb0-9353-6c4dd8ebdf49", "housekeeper6@abv.bg", false, "John", "Alexandrov", false, null, "housekeeper6@abv.bg", "housekeeper6@abv.bg", "AQAAAAEAACcQAAAAEB5oBPzjbh+k5x3dPv20Kkh5DyHdo8nh7YDBaJRDzB+8/jK4tWTinolhBiRE6tIWIQ==", null, false, "", false, "housekeeper6@abv.bg" },
                    { "511337ed-9e27-49ae-a255-8dc0ab159c08", 0, "d7dc6385-7199-4c1f-8e6b-134108bded52", "housekeeper7@abv.bg", false, "Alex", "Johnson", false, null, "housekeeper7@abv.bg", "housekeeper7@abv.bg", "AQAAAAEAACcQAAAAEIlaz4jv8vsIvAVMKDlSJRf+4DuDv8TBAiLB3C+Qrxd8qGrOV5OqdYvIS68tbhYE9Q==", null, false, "", false, "housekeeper7@abv.bg" },
                    { "43cc0da6-1564-4abc-82e1-38d5417fe022", 0, "5e065982-98ab-438f-aa4d-bcd3fd176821", "housekeeper8@abv.bg", false, "John", "Alexandrov", false, null, "housekeeper8@abv.bg", "housekeeper8@abv.bg", "AQAAAAEAACcQAAAAELqrxzNwgexDsbaex1zHOqSEbn8u3PrBDwhomTipzhZ/qsgwM34FNZlSEib78WHOlg==", null, false, "", false, "housekeeper8@abv.bg" },
                    { "9a49deaf-a28a-4d91-8b25-77017ef55a86", 0, "01e364b9-afc6-4f57-acc5-04538d9ad7ff", "housekeeper9@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper9@abv.bg", "housekeeper9@abv.bg", "AQAAAAEAACcQAAAAEN16wL9Pgy8TW5gSkC/UHjPWPBEYmxTVrJe2hN2V8t0c73E0vgapcRdNxYf0QEBWUA==", null, false, "", false, "housekeeper9@abv.bg" },
                    { "7a48e85f-6ddb-4cc4-adee-96108c4fb1e0", 0, "2dc186ee-6772-4ce7-a1b4-de64a60e0e75", "housekeeper10@abv.bg", false, "Jack", "Johnson", false, null, "housekeeper10@abv.bg", "housekeeper10@abv.bg", "AQAAAAEAACcQAAAAEMUfOYJn1p0vGKSxGdG7z1nid7S0A0Bt71XNEoEkwskSi8N1/arBurrXJ/J6GXRY0Q==", null, false, "", false, "housekeeper10@abv.bg" },
                    { "276d3d90-6edf-4421-94e3-602b1358e8b4", 0, "3c2c0f15-8511-425b-988d-6eb53fddb908", "client95@abv.bg", false, "Alex", "Johnson", false, null, "client95@abv.bg", "client95@abv.bg", "AQAAAAEAACcQAAAAEBLNKEKkHNZzBZNwNyCWXDoWiw+2/rGoi20oBP6YyNa57nSocTFAwneMMmQFmoKXGQ==", null, false, "", false, "client95@abv.bg" },
                    { "bdeaae0c-3ec9-49c6-8a41-53cdb2c758bf", 0, "ad272379-368d-472a-9fb3-2b113cb0056a", "housekeeper11@abv.bg", false, "Jane", "Johnson", false, null, "housekeeper11@abv.bg", "housekeeper11@abv.bg", "AQAAAAEAACcQAAAAEBVJDvvRb+otH3TpUkpU8yXgcvhfN6tanEIdlCcvLGZcXJMg0VxT7YyzBo2CnT2Xtg==", null, false, "", false, "housekeeper11@abv.bg" },
                    { "b27926f4-2084-49a1-aee8-b0c5976ef21b", 0, "b13cae18-3250-42eb-b86f-ea6a0363ad96", "client94@abv.bg", false, "John", "Johnson", false, null, "client94@abv.bg", "client94@abv.bg", "AQAAAAEAACcQAAAAEG3GjbZTJ3d+bkj2EEiZ6F6NgqSz1fTE4PlV2mE51upHbeLlSp7COn7yXeQhBqz3EA==", null, false, "", false, "client94@abv.bg" },
                    { "90e4fa2c-68ff-45c9-b381-ad09cd9d9572", 0, "6878a1cb-a256-437c-8490-08dd1bb80001", "client92@abv.bg", false, "Jane", "Johnson", false, null, "client92@abv.bg", "client92@abv.bg", "AQAAAAEAACcQAAAAEBpMHQ+Tm+Iycu3JSxaPZm7nNja15AckF9gcn5WtAPl2PjiQnuXzzY/RxHOxb5u07g==", null, false, "", false, "client92@abv.bg" },
                    { "3858e5b2-5a9c-4e2f-9c45-60b97bfaf369", 0, "021a2785-07b7-4b1d-8588-bd8f98bf1223", "client77@abv.bg", false, "Alex", "Johnson", false, null, "client77@abv.bg", "client77@abv.bg", "AQAAAAEAACcQAAAAEHMWNTUdbf3xUdwAMnTL07NiPf6zTIhhdRKFbes/rjM70KEgJSNo+dBl4Tc+1kh01Q==", null, false, "", false, "client77@abv.bg" },
                    { "9ecd7ee4-efc4-43fc-94e3-7c089c19eaa5", 0, "ea1e95f5-eb6e-492a-a38e-a2e24e1c8290", "client78@abv.bg", false, "Jane", "Johnson", false, null, "client78@abv.bg", "client78@abv.bg", "AQAAAAEAACcQAAAAEO59sQZsILjspD2+r5rRD9dZXge3iZrsAF1rMfkbcyKdL8IWaUtN+useZpOoIhXuug==", null, false, "", false, "client78@abv.bg" },
                    { "edec9150-ad25-4dcc-bebe-2d33f232039d", 0, "8dc73175-9950-409c-ba91-b12e92c40a16", "client79@abv.bg", false, "John", "Alexandrov", false, null, "client79@abv.bg", "client79@abv.bg", "AQAAAAEAACcQAAAAEOM4A6cLUWsfSTc+QItgyyqUewBG1cYVdGnOqsyQUFXjU2jqoQ2WO+ZYtwIrp893cw==", null, false, "", false, "client79@abv.bg" },
                    { "61f1bd78-0d67-4d74-8727-eb10a8146f80", 0, "dcb69cbd-bf77-41df-969a-ee87e15bb2d2", "client80@abv.bg", false, "Jack", "Johnson", false, null, "client80@abv.bg", "client80@abv.bg", "AQAAAAEAACcQAAAAEOUa+zk4NpH31Xyal7x1kbjOfK2ciJ7zMqc6VckxMR7CXm+VF1Ns+cXnDHyDl+gFOg==", null, false, "", false, "client80@abv.bg" },
                    { "410d44e2-a3df-4189-a1c6-8b2dccf6288b", 0, "184c5cef-c59a-4264-8f02-736f03cb9226", "client81@abv.bg", false, "Alex", "Alexandrov", false, null, "client81@abv.bg", "client81@abv.bg", "AQAAAAEAACcQAAAAEH99b6ucBfh23wWC61foSF0bq8+Cd3piJALmH7FM+OQfk9ci8cO0UgW/okW9OhHf1A==", null, false, "", false, "client81@abv.bg" },
                    { "1a5567a6-ebc4-456c-9b5f-5ce1851b43c7", 0, "ebe0b009-2d6a-4abb-88a3-7051448908d5", "client82@abv.bg", false, "Jane", "Johnson", false, null, "client82@abv.bg", "client82@abv.bg", "AQAAAAEAACcQAAAAENhpsNsDhxKDlhJ6mvywWILEPRuDmTiWNn23D3iLQ1gtvMXlG2XBQ0Z7Lfw39l7DNw==", null, false, "", false, "client82@abv.bg" },
                    { "96c349b3-ba57-4c23-b107-508fb365c593", 0, "575db818-a8b3-484a-baab-964f9d2cb347", "client83@abv.bg", false, "John", "Alexandrov", false, null, "client83@abv.bg", "client83@abv.bg", "AQAAAAEAACcQAAAAECt53ii5pZJT0Tnohjo522JNsVkU83bgzYV0xyzP2GEb2/TriTexoQ8c/hq+ek1p8w==", null, false, "", false, "client83@abv.bg" },
                    { "7b3c3e29-3043-46a6-91d8-a2e835bca47c", 0, "fccae6e0-6436-4728-81d5-7ac89671a773", "client84@abv.bg", false, "John", "Johnson", false, null, "client84@abv.bg", "client84@abv.bg", "AQAAAAEAACcQAAAAENOi2jFSdepKdIVMtzVckDoEH3l947keNHZ3k+IXxN/PWI/X3HuX69dZOLZvh4UclA==", null, false, "", false, "client84@abv.bg" },
                    { "e983658e-5955-4713-b859-edb1bd35dcad", 0, "ac77bf1d-7201-496d-8b94-7c165ea3b023", "client85@abv.bg", false, "Alex", "Johnson", false, null, "client85@abv.bg", "client85@abv.bg", "AQAAAAEAACcQAAAAELBlLlXNOad48xwKcUYWRClIkpFm9kdiMuDU+06qrVQTYdZlX7fxWVyy9Fm7Fwz6vw==", null, false, "", false, "client85@abv.bg" },
                    { "b508a744-e79f-4efc-b970-eaa6a3281646", 0, "43223569-5afe-4645-bdf6-0bcfbbfb0438", "client86@abv.bg", false, "Jack", "Johnson", false, null, "client86@abv.bg", "client86@abv.bg", "AQAAAAEAACcQAAAAEOkjY8j/aFedh5Mn+iXjfWyXXb8FgtX7vtyQG39PryHld44kNMrbV6UsRH4JLfajqw==", null, false, "", false, "client86@abv.bg" },
                    { "9e7e0e5c-113c-40c1-90d3-e398460219ea", 0, "764c0c7f-c2c5-43b6-bce5-aab638b33dc8", "client87@abv.bg", false, "Alex", "Alexandrov", false, null, "client87@abv.bg", "client87@abv.bg", "AQAAAAEAACcQAAAAENfVGfdou7mhPjpQdqQzn2ADYhUGtbpuWtsoI4u6DtAFQRfV1LTWlaeEJn+Qf2tObA==", null, false, "", false, "client87@abv.bg" },
                    { "dd8f1cef-b20d-46ab-bb0c-f030b8154e54", 0, "980228ae-a21b-460f-a7f3-94d7719fe168", "client88@abv.bg", false, "Jane", "Johnson", false, null, "client88@abv.bg", "client88@abv.bg", "AQAAAAEAACcQAAAAEH4vkDbU87VKGW12cR6S2XsqHF4fkbjP2kROSsh38M+zX+fOZrY4URCuF3F5tlPArw==", null, false, "", false, "client88@abv.bg" },
                    { "5e7b5b8a-0af6-4839-b18b-f19f151e2eec", 0, "db69fd32-aca5-49a8-a237-031477e234e8", "client89@abv.bg", false, "Alex", "Alexandrov", false, null, "client89@abv.bg", "client89@abv.bg", "AQAAAAEAACcQAAAAEI95/4BH1u47HrBgDuiHLNkV2lr5e0cklDZhUoUFNpDZexfK1cLQrAruuiXfKxOMjA==", null, false, "", false, "client89@abv.bg" },
                    { "21b06bfd-89be-4c6f-a786-df1370423986", 0, "90f364a6-03c7-463a-9a8c-89934ac36461", "client90@abv.bg", false, "Jane", "Johnson", false, null, "client90@abv.bg", "client90@abv.bg", "AQAAAAEAACcQAAAAEOItBMysTKaoOwaaDxXE1la1uu4JV/jaiFhEsh3eIff9/53QPKz0dDK8bElhLpGZww==", null, false, "", false, "client90@abv.bg" },
                    { "e32675aa-edae-4442-9ade-0ef56d5be33d", 0, "bc6ef05c-d2c2-4f00-b0ba-31120ff0bffe", "client91@abv.bg", false, "Jack", "Alexandrov", false, null, "client91@abv.bg", "client91@abv.bg", "AQAAAAEAACcQAAAAEP+DAaaH9bweqt5nKpEnWswx3xr4snTgjNVxjIv44AkF/Uy4ZkskcS5s1Z+KlK1f6w==", null, false, "", false, "client91@abv.bg" },
                    { "47012b59-c03c-4d5b-b19d-a56620f2fdcc", 0, "ab072ad7-7609-41e6-a340-6143e98e77af", "client93@abv.bg", false, "Jack", "Alexandrov", false, null, "client93@abv.bg", "client93@abv.bg", "AQAAAAEAACcQAAAAENB4irGqRihIHu2fm4IcCHYqBDuxJz+/RpEJ/QHRxuVgFaDWxQZTuf1SRN8hERjA1g==", null, false, "", false, "client93@abv.bg" },
                    { "cff7bcdb-dc61-4a52-9de4-aa89cae0e40c", 0, "e36d0c0d-43bc-4d8d-b340-f14278b3d5c1", "housekeeper49@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper49@abv.bg", "housekeeper49@abv.bg", "AQAAAAEAACcQAAAAEFjZhhIHPWHKL+aAby+R9lRLVwrkQPuOL0QtvPmLObNSJXjrgYWCzQxUiUHejqlnmA==", null, false, "", false, "housekeeper49@abv.bg" },
                    { "db6abb77-cebe-4a16-bb72-64829baaa9cc", 0, "cb4d6b43-f530-4109-aecd-1b7be5c2387f", "housekeeper12@abv.bg", false, "John", "Johnson", false, null, "housekeeper12@abv.bg", "housekeeper12@abv.bg", "AQAAAAEAACcQAAAAEJmaoPgPjCKOlFPGrp2OcBYzOXa33DFXZIkZxt/aL7aDenuJ8Tui0wuQMj6QpptL7w==", null, false, "", false, "housekeeper12@abv.bg" },
                    { "35e6caa5-5f87-4b24-a3f4-005fb222d9c4", 0, "98db8ddc-247e-4d89-a356-0c96aef2ca08", "housekeeper14@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper14@abv.bg", "housekeeper14@abv.bg", "AQAAAAEAACcQAAAAENcMudoXnTrnKqMtlCGrmA9976jwCCRYb+B2773/v2tRp3FMUccmxxSLcCZnL70mTA==", null, false, "", false, "housekeeper14@abv.bg" },
                    { "a0b7f711-2bf3-4477-8dd8-4056810c6120", 0, "5bc94f3d-4823-4925-a01d-2f5a84fe81c4", "housekeeper34@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper34@abv.bg", "housekeeper34@abv.bg", "AQAAAAEAACcQAAAAEPXBFdYBYUNcW0nN8z00Qv3H/WFxtKiFj9/+M2nt2dIfvUusIHd1Sg6lV/gWVcvdeQ==", null, false, "", false, "housekeeper34@abv.bg" },
                    { "d521400e-bf9d-4dba-bcbb-73a999eb0f0b", 0, "26776f21-75a1-4fb3-b4fc-c8c443e01998", "housekeeper35@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper35@abv.bg", "housekeeper35@abv.bg", "AQAAAAEAACcQAAAAEA0Uvht3SGWO+bSB2Q41j2hyKLnyPTDMS5gGUFC9/A6XVut6TQdCnBf9ho2TiuRFRw==", null, false, "", false, "housekeeper35@abv.bg" },
                    { "0e29dad5-2a76-40cc-bfba-6e4140e7bdb6", 0, "8e1f28a5-4755-4bb5-879f-73f3989c659c", "housekeeper36@abv.bg", false, "John", "Johnson", false, null, "housekeeper36@abv.bg", "housekeeper36@abv.bg", "AQAAAAEAACcQAAAAEKwa6oLAPBDPMNy0xcsC6+EhfNc6g1j5Wn8pfTh5+cFv6K8/n6u7xzQeb0yysCutVA==", null, false, "", false, "housekeeper36@abv.bg" },
                    { "46a82311-8fa7-48b6-b22b-3b97f47b4d01", 0, "c64c2ad3-0d16-4c6b-a4bc-da87b4ddca7a", "housekeeper37@abv.bg", false, "John", "Johnson", false, null, "housekeeper37@abv.bg", "housekeeper37@abv.bg", "AQAAAAEAACcQAAAAEKtfqcUE3b06RYibXsqSWc48LEe7Jq2/eaVZAsUW5yum+UI9Ca7AwQ5g/lvZlOpfHw==", null, false, "", false, "housekeeper37@abv.bg" },
                    { "9671f718-f477-444b-81fe-f55876bb0c4f", 0, "62453ff3-fcd5-4118-8715-2513087f4fa9", "housekeeper38@abv.bg", false, "Alex", "Alexandrov", false, null, "housekeeper38@abv.bg", "housekeeper38@abv.bg", "AQAAAAEAACcQAAAAEFrDN4XEcHI5JYHf2uUCD7tUDnJhTYRmTm40620X66RyLy/oa1e1ORZboTNs5Z2RZw==", null, false, "", false, "housekeeper38@abv.bg" },
                    { "c31229b8-97ca-4407-b5b3-9c03d9751337", 0, "89c48757-aeeb-4ac9-9bde-4063c8ee7a48", "housekeeper39@abv.bg", false, "Jane", "Johnson", false, null, "housekeeper39@abv.bg", "housekeeper39@abv.bg", "AQAAAAEAACcQAAAAEGc9mEVY9YOmxC/MqXFroEXP56FenMK+VquHwgKe8j10rqDmkJwf6pUPxr4FgZ/RrQ==", null, false, "", false, "housekeeper39@abv.bg" },
                    { "3a29eea6-67ad-4ca6-a4b6-d0df13f9f80c", 0, "7f5e3e9d-abb9-4e48-9ae1-85958c74471b", "housekeeper40@abv.bg", false, "John", "Alexandrov", false, null, "housekeeper40@abv.bg", "housekeeper40@abv.bg", "AQAAAAEAACcQAAAAEIwjUPXpm3W3kRLLJC6ESeg6lGA//4qCpvCW/H3iWPIbaY0YDlNO14rn4KGlRl/8Qw==", null, false, "", false, "housekeeper40@abv.bg" },
                    { "0e82eb19-b2d2-48ae-864d-aaafa11283f3", 0, "4330f068-f8d9-4333-9596-b9a480714b14", "housekeeper41@abv.bg", false, "John", "Johnson", false, null, "housekeeper41@abv.bg", "housekeeper41@abv.bg", "AQAAAAEAACcQAAAAEOHYpatCaEqw4o1ieLIIVkmXDgsRP9HB54uA3JZsRKM9w6O+2nU2D9RQuhyfYQuI/A==", null, false, "", false, "housekeeper41@abv.bg" },
                    { "1800a1cb-7d0e-4ab4-a56c-0f725fb3974e", 0, "d1c1d477-0390-4e8d-bd60-0ae34d74ec6d", "housekeeper42@abv.bg", false, "John", "Johnson", false, null, "housekeeper42@abv.bg", "housekeeper42@abv.bg", "AQAAAAEAACcQAAAAEOZ0XUx6X4D2J4p7+bHY7K1iE96H7o/qxi2EXuWZaLoF7DJpxNTysh5RJRcykBhCQg==", null, false, "", false, "housekeeper42@abv.bg" },
                    { "89ae1438-e3c1-4924-add6-288bbb12aa4d", 0, "9a2a2b2f-86f0-446b-ae4f-7234806f71c9", "housekeeper43@abv.bg", false, "Jane", "Johnson", false, null, "housekeeper43@abv.bg", "housekeeper43@abv.bg", "AQAAAAEAACcQAAAAEEXByabptbqg8ljNS5G257YzLAha990hwdloUPCrCMXEpVbi3Eis0Eo3tN2W4ejoig==", null, false, "", false, "housekeeper43@abv.bg" },
                    { "1128dd3d-802d-474d-9be3-20cd8ef27c6d", 0, "b70cf98f-a21e-458b-b6c1-fdc535e3b10d", "housekeeper44@abv.bg", false, "John", "Johnson", false, null, "housekeeper44@abv.bg", "housekeeper44@abv.bg", "AQAAAAEAACcQAAAAEDwmmubHV2G7dj64GAFsx5M+fjbml1LH3qtC+sa6/6Thgv798+c7J5PEgXNW2wDbIg==", null, false, "", false, "housekeeper44@abv.bg" },
                    { "c6aa36ed-c85b-4ac1-9728-ba301bc6050e", 0, "e821d629-422e-4c6e-80b7-345f53904c4a", "housekeeper45@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper45@abv.bg", "housekeeper45@abv.bg", "AQAAAAEAACcQAAAAELYLOqGL7hXRum0Lz3AopTpyRrMv/fB0PArbVYIWdcrKhB25jVz3QswgBziSzh8FQw==", null, false, "", false, "housekeeper45@abv.bg" },
                    { "9221af3b-78c1-4ffe-98e9-c06ba3f2cbc6", 0, "e00d99dd-cde2-4a3a-b07d-b9b4e8385fe3", "housekeeper46@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper46@abv.bg", "housekeeper46@abv.bg", "AQAAAAEAACcQAAAAEGPLY93cee+szTxpYbinxrqvJuhc/ilXdCxdP7rznSkvThfRG0h2KtAGWfrtamS37w==", null, false, "", false, "housekeeper46@abv.bg" },
                    { "7450dc73-e1a8-4c5f-aaab-821faa7ba1c4", 0, "c7e0e148-a500-48ee-9146-4d6d51b117d2", "housekeeper47@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper47@abv.bg", "housekeeper47@abv.bg", "AQAAAAEAACcQAAAAEOFg9KCqHUCg+So85Ncu2L7lTUy6K+I8sK7UneqzewsKesbrY3XZh3zf5x3PVBkpkQ==", null, false, "", false, "housekeeper47@abv.bg" },
                    { "894ecb41-0259-48c1-b414-99f57f738380", 0, "c71dcdc3-7024-4dfa-a493-9b61366680f6", "housekeeper48@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper48@abv.bg", "housekeeper48@abv.bg", "AQAAAAEAACcQAAAAEELKswlYOhbukbzMop88WBpRWPxqRV4VTIngJ0Mv0vh6viX96dLcuOo7gJNmEkJXnw==", null, false, "", false, "housekeeper48@abv.bg" },
                    { "f5121409-9aad-4dd0-863a-8253bb36898a", 0, "920ff147-3871-4221-a3d7-835c85d42f70", "housekeeper33@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper33@abv.bg", "housekeeper33@abv.bg", "AQAAAAEAACcQAAAAELGRUQ53+IFIQq1HubAlD7hQMNaBbGV+krP+yxQnqz3OhAeOR3ChnuDKZwTS/Q4hNA==", null, false, "", false, "housekeeper33@abv.bg" },
                    { "8f1b7530-7517-436f-a344-d2bdb711eda8", 0, "cd8aef2d-497a-48e6-a5da-73be87cb0909", "client76@abv.bg", false, "Alex", "Johnson", false, null, "client76@abv.bg", "client76@abv.bg", "AQAAAAEAACcQAAAAEBBt6P+6caRM8km/LKJv2CINHTZVifQDqFZM7hUxRTw0m+Isl68HgHXNvRGSJDjOtg==", null, false, "", false, "client76@abv.bg" },
                    { "86407c75-8966-4f49-96e0-549ac0f1b00c", 0, "818fb5d0-5b76-403c-a081-400709fe9806", "housekeeper32@abv.bg", false, "John", "Alexandrov", false, null, "housekeeper32@abv.bg", "housekeeper32@abv.bg", "AQAAAAEAACcQAAAAEJ84Swalhpi6qFM1mK1DbUqdduKpHLMbiaTxEXWBCBUnTUnRd+BU0b5lwuFjYLvEbA==", null, false, "", false, "housekeeper32@abv.bg" },
                    { "6482957f-57f1-4dd9-9ea2-6a9bef20d208", 0, "003c87b0-37d0-4c87-bc7e-d02ccda4ff21", "housekeeper30@abv.bg", false, "Jane", "Johnson", false, null, "housekeeper30@abv.bg", "housekeeper30@abv.bg", "AQAAAAEAACcQAAAAECZM5452g7A3bbJB4A5qzHhiwusXZWCxfiXlpX6X7S0Bwsh+fHvApB/uaNvRhG+RBA==", null, false, "", false, "housekeeper30@abv.bg" },
                    { "bcf87598-67e8-40f6-8510-d51aac5ec78c", 0, "dc69cd7e-4a00-420e-b114-e4e9bc5c092f", "housekeeper15@abv.bg", false, "Jack", "Johnson", false, null, "housekeeper15@abv.bg", "housekeeper15@abv.bg", "AQAAAAEAACcQAAAAEAfvyT+Onhw+QPjMq3jLChflqjKCWNdPpj4QJdkfWsh6oHFXwvfedbd1Xf7V/La8Rw==", null, false, "", false, "housekeeper15@abv.bg" },
                    { "6c7c6fdc-99e7-484a-9391-c1bbdc35660e", 0, "99a4cabc-1a09-4d35-b0b1-601f6a9d6497", "housekeeper16@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper16@abv.bg", "housekeeper16@abv.bg", "AQAAAAEAACcQAAAAED4/5SFU6KgpJESN4KC5VTrS+O0mJyjRosj/cD9hcuqopDbId4svVGOt7UCen5jj5g==", null, false, "", false, "housekeeper16@abv.bg" },
                    { "5d1ed47a-6fea-4eb0-ba14-1e02ed752cf5", 0, "25fd75c2-130f-4091-ae71-2fa1e5ed3dbc", "housekeeper17@abv.bg", false, "Jack", "Johnson", false, null, "housekeeper17@abv.bg", "housekeeper17@abv.bg", "AQAAAAEAACcQAAAAEPJvcxFB0UqIuJrAV14THLKGdJF/sAXguF3fgByeI2nY6lg1Hs+pbEafj5+0UehLyg==", null, false, "", false, "housekeeper17@abv.bg" },
                    { "c264e5cb-ac77-422a-b9ae-66e45f45cff8", 0, "31b2fe30-b639-4d6c-a29a-ce84b3d1bbc8", "housekeeper18@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper18@abv.bg", "housekeeper18@abv.bg", "AQAAAAEAACcQAAAAEBFwECdF8Vabam3KHGFB3Tg0X6HdnKx5gQzjsHbt31P5s5q+gBcLCOKtoLE7RbC52A==", null, false, "", false, "housekeeper18@abv.bg" },
                    { "22345e60-eb29-408f-ae2e-c09a15d03667", 0, "9a13daa7-3c70-4b4c-a07b-12981566075e", "housekeeper19@abv.bg", false, "Jack", "Johnson", false, null, "housekeeper19@abv.bg", "housekeeper19@abv.bg", "AQAAAAEAACcQAAAAECTu2+q7NhjaASoUbqXcDA5pn5BnmjW5jrIn/Zugw0MzA8LDxzC1uQzjQ8ehbxukJg==", null, false, "", false, "housekeeper19@abv.bg" },
                    { "460d59db-bfef-4497-b90b-00bd6bfbecde", 0, "3a2e4437-172a-403a-a712-d8812e0dc9ab", "housekeeper20@abv.bg", false, "Jack", "Johnson", false, null, "housekeeper20@abv.bg", "housekeeper20@abv.bg", "AQAAAAEAACcQAAAAEPofwagZOrtefeKI4UJFJU48jEbhyRcTvFrufUOHhT1hg8vZdyxCQ4tlL8V+PsgBcg==", null, false, "", false, "housekeeper20@abv.bg" },
                    { "4750d1c7-88d6-4d46-a408-cf00338029a4", 0, "b8595fd6-413b-4aaa-86cc-15fc8281dea2", "housekeeper21@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper21@abv.bg", "housekeeper21@abv.bg", "AQAAAAEAACcQAAAAEJ8h9HeLQtwvobki9zRcUTNR2O4no5eZHMS272/8bKlKAIUU9QSeFMy2utDaSoOBNA==", null, false, "", false, "housekeeper21@abv.bg" },
                    { "d95d271a-ff11-426b-b21f-c6e1b67876cb", 0, "abf6bc52-e8cc-4db2-8912-3ea4389cb62a", "housekeeper22@abv.bg", false, "Alex", "Johnson", false, null, "housekeeper22@abv.bg", "housekeeper22@abv.bg", "AQAAAAEAACcQAAAAED0alOtVfKIUtRVU1Lkfl27egE5RsI/Ee0qvaAPKsmVrXQNQQrckLBYZBS/G73sK8Q==", null, false, "", false, "housekeeper22@abv.bg" },
                    { "59717167-f1f3-4327-bfcc-029fc3bf7447", 0, "d378a700-460c-4b7e-a204-350ca1aa1ab8", "housekeeper23@abv.bg", false, "Alex", "Johnson", false, null, "housekeeper23@abv.bg", "housekeeper23@abv.bg", "AQAAAAEAACcQAAAAELpiRFH7akFQTWIJBFOotgBYu7MSr9fgY+c8TSKAmNuIHsxQL8+T7oCtIO2qQUWcrQ==", null, false, "", false, "housekeeper23@abv.bg" },
                    { "c73b658f-c3aa-4297-96d9-0a22b2f395fb", 0, "e73feb1a-307c-4d27-93a7-a18bcb08b1a1", "housekeeper24@abv.bg", false, "Alex", "Alexandrov", false, null, "housekeeper24@abv.bg", "housekeeper24@abv.bg", "AQAAAAEAACcQAAAAEBObAaYjp74jstHAaCotJlH4C/bNh+KNt8OQmCWudXY0alAqQWAYCAJ11WzkdWTeNA==", null, false, "", false, "housekeeper24@abv.bg" },
                    { "0bb9c8f6-30b4-4185-8f06-83f4f1741d19", 0, "9da88850-7176-4541-9702-4f2fafded0c7", "housekeeper25@abv.bg", false, "Jane", "Johnson", false, null, "housekeeper25@abv.bg", "housekeeper25@abv.bg", "AQAAAAEAACcQAAAAEFMrBNrUucJlfS0TIsyC9Lu9Cuargy69ZSYFzMwlmPBj5lqkx6cnlu+53y3TIOdgrQ==", null, false, "", false, "housekeeper25@abv.bg" },
                    { "2caba972-7562-481b-8074-f8a58d50c4f8", 0, "417fbdd4-d4f6-4c1a-a518-aee9d12ef2f4", "housekeeper26@abv.bg", false, "Alex", "Alexandrov", false, null, "housekeeper26@abv.bg", "housekeeper26@abv.bg", "AQAAAAEAACcQAAAAEN8CFBEsIOowmOyCxh3NFqXkGOcmjvVbgwkJ0xUYTSkwn+tdTd90AmAJiG1ITD7Ehw==", null, false, "", false, "housekeeper26@abv.bg" },
                    { "7fda7c7c-ef19-4c51-a493-edc5de0cee24", 0, "37342a59-9821-4c47-98ff-8b7197233145", "housekeeper27@abv.bg", false, "John", "Johnson", false, null, "housekeeper27@abv.bg", "housekeeper27@abv.bg", "AQAAAAEAACcQAAAAELfqGU8NSr6FwY/OoWFmq4gJDvz12t6ObnPlpSSRVyEQa5DHJ7kSDh0eauYBvk0hAw==", null, false, "", false, "housekeeper27@abv.bg" },
                    { "20df404a-a19d-44fc-83cf-0464e249fb66", 0, "8ab2ebf8-71a1-4040-abac-84ced81ada80", "housekeeper28@abv.bg", false, "Jane", "Alexandrov", false, null, "housekeeper28@abv.bg", "housekeeper28@abv.bg", "AQAAAAEAACcQAAAAENUkQmhz7Aj47NVKl0EYl7vZzWEt1F56ajnYPlUex2zxTX/tclNdWvzNzZJCSWxWrA==", null, false, "", false, "housekeeper28@abv.bg" },
                    { "43d137ed-c8bf-4547-abdc-b34bae1e9534", 0, "4d8d11a5-e4b5-4a72-899a-1b54cda494ff", "housekeeper29@abv.bg", false, "Jack", "Alexandrov", false, null, "housekeeper29@abv.bg", "housekeeper29@abv.bg", "AQAAAAEAACcQAAAAEEKBVFOL1NavBIRxTjQA0Y5rxGFzT0fEyPPusg6DekhaDH2Ohv8FOT/k3U3+itOUkg==", null, false, "", false, "housekeeper29@abv.bg" },
                    { "23af98bd-1efe-423f-9e53-4000faf44345", 0, "c84f9775-aba0-41ab-84b2-a8cd229ce0bb", "housekeeper31@abv.bg", false, "John", "Johnson", false, null, "housekeeper31@abv.bg", "housekeeper31@abv.bg", "AQAAAAEAACcQAAAAELCFgaqKdNXW9G850J8MzFN9WGHTebUlznppb5/13oyobFOl9vpFRMk8c8J538gTFQ==", null, false, "", false, "housekeeper31@abv.bg" },
                    { "5f0532b3-e02e-432b-a6f6-498c903ec75c", 0, "1eaf7524-a5d0-4db2-9af6-a6359c7c2a59", "housekeeper13@abv.bg", false, "Jack", "Johnson", false, null, "housekeeper13@abv.bg", "housekeeper13@abv.bg", "AQAAAAEAACcQAAAAEKPeGn9LZVcNroRR507iuK76A2uzb7t3ZdN08oxg83a5AVP5jVms1+efNF147QDTlw==", null, false, "", false, "housekeeper13@abv.bg" },
                    { "4a2c08d3-6813-473c-a0b6-d96e25e4049f", 0, "2f861711-0c24-4fc7-9cb3-faa2f54504ff", "client75@abv.bg", false, "Jack", "Alexandrov", false, null, "client75@abv.bg", "client75@abv.bg", "AQAAAAEAACcQAAAAEDwjL5YE8BLOl2PnsMotfTQmgXuhqGmgYLT481FejWOSmGfUWUKu0h5w+IFzcxYwdw==", null, false, "", false, "client75@abv.bg" },
                    { "f369707c-405a-453b-ad2d-e2902a2fcd9a", 0, "fab67916-8520-4bb3-932b-74935e6edb45", "client73@abv.bg", false, "John", "Johnson", false, null, "client73@abv.bg", "client73@abv.bg", "AQAAAAEAACcQAAAAEO+GY364lXAOiNDbjVNq5ejaLjUiu9WQcAgDArBkJauH1DyAh/sXubgVz55UUXZD3g==", null, false, "", false, "client73@abv.bg" },
                    { "5a24df45-4625-44a1-90c5-1540eff277fc", 0, "6355a527-9e00-4ae0-a514-0feabf2821e9", "client19@abv.bg", false, "John", "Johnson", false, null, "client19@abv.bg", "client19@abv.bg", "AQAAAAEAACcQAAAAEGP6WW3+SwRlNcA58SFT8tkwHiv5smu/MY9QvqQD9EHefuPGs4MzVs9oyH2O9eHMjQ==", null, false, "", false, "client19@abv.bg" },
                    { "a3181a1d-ce67-4b52-980d-823a3bf1a8ec", 0, "a81d91e8-8d9b-4439-84a0-3f06d5b1ae78", "client20@abv.bg", false, "Jack", "Alexandrov", false, null, "client20@abv.bg", "client20@abv.bg", "AQAAAAEAACcQAAAAEBKzksyZpTEmUThgKdeQgVdm20VRe64tmXuFP/wRapncDlCNn5GffX6s+9m/J/5H7A==", null, false, "", false, "client20@abv.bg" },
                    { "b1f44b75-b428-4965-abdd-67c8826616fe", 0, "b85dcbe1-1c20-4903-ba96-99d4054a1c85", "client21@abv.bg", false, "John", "Johnson", false, null, "client21@abv.bg", "client21@abv.bg", "AQAAAAEAACcQAAAAENk/txhZ2qljU5mz8GHQ9resTkfk2qHeal0Rbf+wFcqo2HSRFJZT3lNERtst1IgX1g==", null, false, "", false, "client21@abv.bg" },
                    { "1c353b70-bbc1-4702-a786-7fe4a4e4dfc4", 0, "8e225d25-7450-476b-ba53-01dae5c14902", "client22@abv.bg", false, "Alex", "Johnson", false, null, "client22@abv.bg", "client22@abv.bg", "AQAAAAEAACcQAAAAEN3HHW26vXtXF3T9flPT/nAWzpjKx5fDnFiXR4bpJdkNnGGweQxFiiz4hfa1K/fXnQ==", null, false, "", false, "client22@abv.bg" },
                    { "7fe0425d-a5c7-41cb-a659-6624fb8ab1d3", 0, "ce9163ed-be15-4d66-a20c-9054d3b7ec7f", "client23@abv.bg", false, "Jane", "Alexandrov", false, null, "client23@abv.bg", "client23@abv.bg", "AQAAAAEAACcQAAAAEBhk75+aOQD0A4+4v6c+zoVts7jbByCojetDDMc2KywgMnyulrykOMfQrVy6iusBmQ==", null, false, "", false, "client23@abv.bg" },
                    { "7c60bad0-cb6a-4126-8106-c929941c630b", 0, "08818694-8a28-4686-bf34-293539bcb86e", "client24@abv.bg", false, "John", "Johnson", false, null, "client24@abv.bg", "client24@abv.bg", "AQAAAAEAACcQAAAAEGazfnMU2gag8edwpFLy/UDDiN4eALlypE1wRGfvu0P7n4FS/ioWxglSTd3QLjIPRg==", null, false, "", false, "client24@abv.bg" },
                    { "2da86768-7f07-4f55-83a1-ad248ee5a9ec", 0, "578d41cf-d7e3-4501-9084-ad60bace1b44", "client25@abv.bg", false, "Jack", "Alexandrov", false, null, "client25@abv.bg", "client25@abv.bg", "AQAAAAEAACcQAAAAEIy4MWFfa9HsUWR7L/IZFm8mlMxwKjDz0q9azNGohUaYr8svv9Xm2+3rbNQtptAhFA==", null, false, "", false, "client25@abv.bg" },
                    { "4ba63feb-16e6-4c94-837f-c99463b32ecb", 0, "a38ef135-3145-4785-ab1d-003fd98d79f3", "client26@abv.bg", false, "Jane", "Alexandrov", false, null, "client26@abv.bg", "client26@abv.bg", "AQAAAAEAACcQAAAAENzLlVoFZX/bGhhw/U7QumwSN5FQP6pHgVENh0T4xGQD4r537jUajFRb89TqwO7U+Q==", null, false, "", false, "client26@abv.bg" },
                    { "b08bda2c-ddd1-4a5f-8fe2-fdaad28dff64", 0, "f6b7df70-41e0-4129-a560-3293ab6a701c", "client27@abv.bg", false, "Jane", "Johnson", false, null, "client27@abv.bg", "client27@abv.bg", "AQAAAAEAACcQAAAAEJ6vggAEyVZ4egbAK6okLjKK+Ktq/h0UYl5tLGm+OQchjSIIBkKduT3KQTZ4Y4rtJA==", null, false, "", false, "client27@abv.bg" },
                    { "6e7f9b7b-1bcc-4e7a-b59a-58feecbfa386", 0, "4ab2c4e6-d348-4743-b770-f3d3afca8344", "client28@abv.bg", false, "Jane", "Alexandrov", false, null, "client28@abv.bg", "client28@abv.bg", "AQAAAAEAACcQAAAAEBe+mAQBknD63J3WXZuX73EIQ9gDF6C+FQsDzsUOwSkLtic6Zkz5+nfqMdsUuYIhbw==", null, false, "", false, "client28@abv.bg" },
                    { "b463d853-37fa-43c5-80a8-050fff6a258a", 0, "0391c418-f3a7-4f2e-b815-4ac2b1229924", "client29@abv.bg", false, "Jane", "Alexandrov", false, null, "client29@abv.bg", "client29@abv.bg", "AQAAAAEAACcQAAAAEBw+utt+zhwSzvzcE77qRmilio951IuG2CV3wNCYIOkhYY42rJIxXqLwgt42BPZxAg==", null, false, "", false, "client29@abv.bg" },
                    { "b5663631-94d3-4c44-b500-09cb126f081a", 0, "f88cdb63-e2f4-4063-89c4-76acafe3b7d6", "client30@abv.bg", false, "Jane", "Alexandrov", false, null, "client30@abv.bg", "client30@abv.bg", "AQAAAAEAACcQAAAAEH84zzJY+pvptAe3ZJweyKXlp7juOeaiqh7PfGseHqzrroun/hcFa1fIaM2x9qBxjA==", null, false, "", false, "client30@abv.bg" },
                    { "b462a280-c82e-4c83-8df9-777b87a541d2", 0, "8b9ae6ff-a848-4078-8d72-46eea845a8ba", "client31@abv.bg", false, "Jack", "Alexandrov", false, null, "client31@abv.bg", "client31@abv.bg", "AQAAAAEAACcQAAAAEH+j3GmkHVm+lf5MIK/76qktaV3SfIVZCTqEPOZEm1j9doE5hwAwh+LnMLzwI/znNQ==", null, false, "", false, "client31@abv.bg" },
                    { "7637299f-cc9d-4a66-9b99-80fc96a8c35f", 0, "cb117536-924d-45ea-b305-63babff2479e", "client32@abv.bg", false, "Jane", "Johnson", false, null, "client32@abv.bg", "client32@abv.bg", "AQAAAAEAACcQAAAAEMNFMaSR/CDF8yxkIeE9jDZLS4fmtXHr5wOvGyJOo97rQ+9QK3o2QjWgHHkq1toiBA==", null, false, "", false, "client32@abv.bg" },
                    { "dc8053f3-07e9-47b2-9881-85978619f8da", 0, "0aa00155-a829-43c7-a611-45fd1e990ff6", "client33@abv.bg", false, "John", "Johnson", false, null, "client33@abv.bg", "client33@abv.bg", "AQAAAAEAACcQAAAAEOeBXsEi9PD/THI5MiWoEarL/kzaMqJ7YcG9Sdu9vRnc3h91MCXmMBJ0nvbLF0ZNnA==", null, false, "", false, "client33@abv.bg" },
                    { "1970d163-17a5-4c09-b2dc-344283cfa14e", 0, "fe571e77-3f3a-451e-ad37-56ffd4cdfbb9", "client18@abv.bg", false, "Alex", "Johnson", false, null, "client18@abv.bg", "client18@abv.bg", "AQAAAAEAACcQAAAAEFUUMM7VHn0ZVRQltc1Y91M1taQnVBbQdggo/1hyIYNzYOYNRMkMhSYWH+kwgDpd2g==", null, false, "", false, "client18@abv.bg" },
                    { "01487671-e41c-467e-8528-1cbff7ef05a9", 0, "36478174-366f-4f81-a2d1-fb6d4fa90f37", "client34@abv.bg", false, "John", "Johnson", false, null, "client34@abv.bg", "client34@abv.bg", "AQAAAAEAACcQAAAAEHDtQI0gonl1qVKLIQXTUq7VWhG5tQluJggS878frxIzjcAGBdDiRTobo+am+I0vVw==", null, false, "", false, "client34@abv.bg" },
                    { "ddfd4dc6-e027-410c-b7c1-52c0aaff7bb2", 0, "71eec5b3-7f61-4a6b-b8cc-0fa94d82f0e6", "client17@abv.bg", false, "Jane", "Alexandrov", false, null, "client17@abv.bg", "client17@abv.bg", "AQAAAAEAACcQAAAAEBbcItk6FTp93ODnh9OkJnm4jPRMDHq4g7rwiMyWprBQqieZHgFkY1Mgpeni0hZp8w==", null, false, "", false, "client17@abv.bg" },
                    { "2150e453-24c2-4074-a426-c9ce7137cc9c", 0, "c1e4cd0e-d84e-44a5-a828-7a454c86fa4c", "client15@abv.bg", false, "John", "Johnson", false, null, "client15@abv.bg", "client15@abv.bg", "AQAAAAEAACcQAAAAEASG7Cn1Vp3V1Dg5BT3iH4totQMt1RQEp2ismBHVkwmxcimCxa9g90vjEwd+/5ZeXw==", null, false, "", false, "client15@abv.bg" },
                    { "ba362fb1-911d-4143-af81-77732d55f80e", 0, "6ea0de27-be76-41f8-b024-6dfb678f4631", "client0@abv.bg", false, "John", "Johnson", false, null, "client0@abv.bg", "client0@abv.bg", "AQAAAAEAACcQAAAAEIoXQ6s6P/bV7h/mRLgP024R+AOL3Rszed64337OKM7DWTKJIpFmlcmKHbJ/TzzUJw==", null, false, "", false, "client0@abv.bg" },
                    { "d6057397-dd38-4fe2-a568-311dbbc8fa0c", 0, "284d25bd-e266-4101-a594-da75ca05204c", "client1@abv.bg", false, "Jack", "Johnson", false, null, "client1@abv.bg", "client1@abv.bg", "AQAAAAEAACcQAAAAELxl2gQccmynMBSMUom/iVfEzkPctZLF9RKjLd1hMoXaxDL01uDFXC9mIYIGdTq9Dg==", null, false, "", false, "client1@abv.bg" },
                    { "da6d8b4f-21a7-4d91-9c22-7819103ffac0", 0, "9a8dc561-ae11-46c0-8791-22b416e12955", "client2@abv.bg", false, "Jane", "Alexandrov", false, null, "client2@abv.bg", "client2@abv.bg", "AQAAAAEAACcQAAAAEJCf2ljQuY40LCJxNdjyP5WAa40+SruWMv1KvmRct8LivoK+IzxZC55MKYVaE0QEwg==", null, false, "", false, "client2@abv.bg" },
                    { "51bcbbeb-05be-4c5c-a19a-7bde18e53f3b", 0, "7e22f378-fb4d-4258-9b3d-ae2209c530eb", "client3@abv.bg", false, "Jane", "Alexandrov", false, null, "client3@abv.bg", "client3@abv.bg", "AQAAAAEAACcQAAAAEI8wc4GhTBvjvj3UIdyHuYFMAtnm2cCQOSxdfmGl27uxGvjJ+++WCdqzQc6pBILj2w==", null, false, "", false, "client3@abv.bg" },
                    { "9c59a319-04ad-452d-bc09-124ba8d2d5af", 0, "f194e3e2-4a90-4481-af3c-cf0bf3a0ced3", "client4@abv.bg", false, "Jack", "Johnson", false, null, "client4@abv.bg", "client4@abv.bg", "AQAAAAEAACcQAAAAEIJXZNIIU9ECP0CMdp4MKnoMWGIvBUV4rOCcqhBVOPEJ65FXMg3ixU6YTvuQsQ0jsQ==", null, false, "", false, "client4@abv.bg" },
                    { "f8b23b94-f90c-4c45-9352-d6c4e5607c0c", 0, "d3599ff0-4e44-45f5-b462-3bcc0bde750b", "client5@abv.bg", false, "Jane", "Johnson", false, null, "client5@abv.bg", "client5@abv.bg", "AQAAAAEAACcQAAAAEMsGw0Tb6zC9FSeEP89E8xvPrgZ3iyC8y4eTgpnogkyih96reL2gZD10HCbWmNfkfw==", null, false, "", false, "client5@abv.bg" },
                    { "9b193e2f-21f1-4677-9b4c-6d18dfe73547", 0, "a855d88e-0e51-4642-9441-a16c82841a3b", "client6@abv.bg", false, "Jack", "Alexandrov", false, null, "client6@abv.bg", "client6@abv.bg", "AQAAAAEAACcQAAAAEDP8y2XnMRwntk8vbX4pdCYeEprtCTqnK4oRvkff7GqQTTc4w6GUKio/LoWwasINnQ==", null, false, "", false, "client6@abv.bg" },
                    { "b8e156f3-3d76-4f3e-8449-355c20083690", 0, "e82b51ae-9d77-471c-97f0-12f9723a5bca", "client7@abv.bg", false, "John", "Johnson", false, null, "client7@abv.bg", "client7@abv.bg", "AQAAAAEAACcQAAAAEC3pd8g04rq36gVUaZSG1XdTE1oPWR2sPlLXMcBEsc3x5gpsWbUrrasEDyR4dkmyKw==", null, false, "", false, "client7@abv.bg" },
                    { "42d9526a-f9e7-42a3-9713-fc420e2806ca", 0, "f917a336-bd24-4e15-b790-5e4aef6718f6", "client8@abv.bg", false, "John", "Alexandrov", false, null, "client8@abv.bg", "client8@abv.bg", "AQAAAAEAACcQAAAAECiMl8DbBhhrQE6Orv1vfsNC2vdjwB6Ra/IvrZslBoAIOBhrvrGcFHI5s5Y+89KFzg==", null, false, "", false, "client8@abv.bg" },
                    { "e436ba0e-7633-4ffc-bf06-588f566bd955", 0, "5faf3025-f0f8-4643-a911-7fdd9f768acf", "client9@abv.bg", false, "Jane", "Alexandrov", false, null, "client9@abv.bg", "client9@abv.bg", "AQAAAAEAACcQAAAAEDRCYUZmKU/7UMCX/XFnMsup2IFtRQBSUDiypOTqZwYan7T4SI5zE+ZPuzP4BefiGw==", null, false, "", false, "client9@abv.bg" },
                    { "6af7e72f-354f-4563-9bbb-7298cadc22ab", 0, "358e5b7a-d10b-48a8-89f5-2673f2627a1c", "client10@abv.bg", false, "John", "Alexandrov", false, null, "client10@abv.bg", "client10@abv.bg", "AQAAAAEAACcQAAAAEMzRmKSK0r/oU7mCdjg+d9mCry1I1etOHEdIaFke0Ay5qHD3Xgs9eF+CnrlpGukENw==", null, false, "", false, "client10@abv.bg" },
                    { "9ddd665a-3b65-4b2a-94f1-c7f406e32451", 0, "96ec3b72-c871-4eea-90f1-5e29d42a4e85", "client11@abv.bg", false, "Alex", "Alexandrov", false, null, "client11@abv.bg", "client11@abv.bg", "AQAAAAEAACcQAAAAEKh4sXFVbWlFODb0vUoWsiGUvXhASi1VZ36nNxs3ZVMaa++5tG7Zl9XS+xBpgZLZVw==", null, false, "", false, "client11@abv.bg" },
                    { "4c1dce67-ff7b-496d-b35c-51d287b60e4f", 0, "3e16b143-5b53-44a3-a070-261ff3d9bcbc", "client12@abv.bg", false, "Jane", "Alexandrov", false, null, "client12@abv.bg", "client12@abv.bg", "AQAAAAEAACcQAAAAEHnyNRc3xZYbGRdy2JzJ0ER2bm2BK+/KqS+NyJz+h2Sk1dvCipcO9QtIuNj6UpfTjg==", null, false, "", false, "client12@abv.bg" },
                    { "2ee8bdc4-1052-467c-a60e-db8c38f16f98", 0, "7a23330b-9d15-45e0-81e5-feb3c640feda", "client13@abv.bg", false, "Alex", "Johnson", false, null, "client13@abv.bg", "client13@abv.bg", "AQAAAAEAACcQAAAAENdGj8qbz6tMY9KHS4c4R6Lx/5rtcRo8qvrRRgGG0mnawg0NDqLUU5VoiKi9KdjlfQ==", null, false, "", false, "client13@abv.bg" },
                    { "6df22645-cfa9-4d97-a69e-9d75673c9335", 0, "68f82622-9820-4905-8050-bf99a35ad176", "client14@abv.bg", false, "Jane", "Alexandrov", false, null, "client14@abv.bg", "client14@abv.bg", "AQAAAAEAACcQAAAAECi7IDJpNdMtaO3lxuy+W2cFX1LFN0jl7N+rXTCEAcyJnaPAiCFX0hEUSAjXGeFBSQ==", null, false, "", false, "client14@abv.bg" },
                    { "a39533a0-2341-4e6b-b93a-4719db3940c5", 0, "0a82fd42-c01f-4538-a171-c55f44fe3f27", "client16@abv.bg", false, "Jack", "Alexandrov", false, null, "client16@abv.bg", "client16@abv.bg", "AQAAAAEAACcQAAAAEPEJ+3/P/FivkY+U5BCnoVSKgSG1zZkcrGIiZMSQfaNuewJcdZ65MBHIqKYNteR7pw==", null, false, "", false, "client16@abv.bg" },
                    { "3ef1ef9e-efa5-475f-b79e-92a5b16a2fe8", 0, "67643f4a-1cf3-4a65-b0b2-2d42aa00a6bc", "client35@abv.bg", false, "John", "Johnson", false, null, "client35@abv.bg", "client35@abv.bg", "AQAAAAEAACcQAAAAEEdrOmoa+XVe+Z9z8h/dbdHCvay6v0SYZu2n1/bJwvdj/UlC8IGFlZ12/Q+utnifJw==", null, false, "", false, "client35@abv.bg" },
                    { "33d89876-87f5-4bd9-a132-35d7644a1ace", 0, "1b74d2cb-ea79-49c6-8fb3-d278248f8f3e", "client36@abv.bg", false, "John", "Alexandrov", false, null, "client36@abv.bg", "client36@abv.bg", "AQAAAAEAACcQAAAAECvzZzc5pk/5x7n2Ud5GIRfbmOqto/sZrz6/P58pH7KpF+AyL8aDPnCW7uST6+u8KQ==", null, false, "", false, "client36@abv.bg" },
                    { "4ba477a8-77df-4152-8884-2a7db6f6a09f", 0, "daf08944-11e2-4554-9bea-29181479f236", "client37@abv.bg", false, "John", "Johnson", false, null, "client37@abv.bg", "client37@abv.bg", "AQAAAAEAACcQAAAAEDHhtGotqhMNhxvb9G/aJBrOal3enhWoRpx/mw5VA0Zqo+D+4o0SOuDPuMYxcM0iDg==", null, false, "", false, "client37@abv.bg" },
                    { "540f0939-b07d-4488-b473-a668dea18858", 0, "969092f3-c9ac-4aad-a25d-07f1c034e2ea", "client58@abv.bg", false, "Alex", "Johnson", false, null, "client58@abv.bg", "client58@abv.bg", "AQAAAAEAACcQAAAAEA+1NVOLVtZGT2tJlvXt7AjG+ULKmZsWnLRm+z41PbTD/Rn9g0h4yXpRrvO/1AqCWA==", null, false, "", false, "client58@abv.bg" },
                    { "3b925854-48ae-4896-ae37-eb2c772424f2", 0, "e6a200f8-5af5-47f4-917b-6e3599b21c52", "client59@abv.bg", false, "Jack", "Johnson", false, null, "client59@abv.bg", "client59@abv.bg", "AQAAAAEAACcQAAAAEFjoMnv+jEQI0EdYQ104DKEAFha+L0IgDSgXVcRoUNm+3DuVlFTkkOPTxrTHuVePGw==", null, false, "", false, "client59@abv.bg" },
                    { "9bbb17ad-2682-499b-8259-3f3983afa7db", 0, "bbdaef3b-d59d-46f4-86d8-f5ee366d52ec", "client60@abv.bg", false, "Jane", "Johnson", false, null, "client60@abv.bg", "client60@abv.bg", "AQAAAAEAACcQAAAAEAilzM6cS5YlJBR3bJ7TdpheYZeHj+PbWOIDZjO0lPwI945WiNN5CG9oEJ1bhwaobg==", null, false, "", false, "client60@abv.bg" },
                    { "9ec037f3-e405-4bb8-816a-5d1e3dd54fbd", 0, "517289e7-fb95-4088-84d4-876ca8ea1484", "client61@abv.bg", false, "Jack", "Johnson", false, null, "client61@abv.bg", "client61@abv.bg", "AQAAAAEAACcQAAAAECJpIOsw7SdADJXNombXIy10LpNy/NT3svYVaWoif9f6P0AKmgDvfK8T9RHzdIPKtQ==", null, false, "", false, "client61@abv.bg" },
                    { "b4d0bd84-6fc4-4f7d-9cd2-9b7e42ef8ee5", 0, "c75a768c-5705-453e-a019-9d4db9de1524", "client62@abv.bg", false, "John", "Johnson", false, null, "client62@abv.bg", "client62@abv.bg", "AQAAAAEAACcQAAAAEBpz5rFsm1qtvIuVD3F6wOV7A/XnFqadSJShGUrPNIzmI1EcM1juV0vl/CbzxDQEiA==", null, false, "", false, "client62@abv.bg" },
                    { "d340d8f7-30a4-420f-b536-7eacea7bc672", 0, "e8149779-5814-4d99-9815-b7402a31e258", "client63@abv.bg", false, "John", "Johnson", false, null, "client63@abv.bg", "client63@abv.bg", "AQAAAAEAACcQAAAAEBiwus0YG06UsiQ1HotPjplsPfq9dzt4b/e5p1ebIWZ8oBKe3o+RlwA60ilMehvcyQ==", null, false, "", false, "client63@abv.bg" },
                    { "8c519f2e-a0cf-4e76-99f4-f2cc39d0e9f0", 0, "288b77bb-7872-4fef-9e93-5ec85d0341af", "client64@abv.bg", false, "Jane", "Alexandrov", false, null, "client64@abv.bg", "client64@abv.bg", "AQAAAAEAACcQAAAAEBnJF04sPhBd/4E9ypRZV2ZRCL5yE+ZS+VWdBC0grFvjF9RE0UOZBSyYxQqFlRv59g==", null, false, "", false, "client64@abv.bg" },
                    { "09f5f987-7fa7-4464-8afd-65796b472e76", 0, "4034e2aa-6712-4200-9aba-ad660fb0d78a", "client65@abv.bg", false, "John", "Alexandrov", false, null, "client65@abv.bg", "client65@abv.bg", "AQAAAAEAACcQAAAAEFfZvSOSXWHAX4B/VwpKp6q5bOX3XJf4wRt5gRRxugzDC7DE39fDPNL3Yb5Ka1QVlQ==", null, false, "", false, "client65@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "df8c7835-859b-4bda-acfb-c026e9476081", 0, "622a1e53-0ef6-4289-acbe-726796a5d246", "client66@abv.bg", false, "Jane", "Alexandrov", false, null, "client66@abv.bg", "client66@abv.bg", "AQAAAAEAACcQAAAAEB/ODQPReI422Zju+Mkg6bNRWLRRttQpSacEvAe3paJIvgLpbnNDvhbwP6YO0mQsMw==", null, false, "", false, "client66@abv.bg" },
                    { "70ec08e2-0915-4105-a9af-9b0d8e509811", 0, "41eefa52-a4de-40db-b437-dd2183f8a94e", "client67@abv.bg", false, "Alex", "Johnson", false, null, "client67@abv.bg", "client67@abv.bg", "AQAAAAEAACcQAAAAEFl94fdfgVVCihfwQnPIa9aqUkx9Qz29C8YIAsXlaI743BXxhG9jYoRNo1gcbdVktQ==", null, false, "", false, "client67@abv.bg" },
                    { "4cf8d15a-256e-4eb0-8507-f9c27dae147f", 0, "79becdb6-71ab-4c92-8fb9-c83c3b43ac65", "client68@abv.bg", false, "Jack", "Alexandrov", false, null, "client68@abv.bg", "client68@abv.bg", "AQAAAAEAACcQAAAAECCqhk3K1CLP+VYP8jwhbFphrDcqdwbmiYbTVkzjGy9SMQNZoRLmaGsLAD0IZL8bQg==", null, false, "", false, "client68@abv.bg" },
                    { "0899c3a0-43f4-4d32-8429-d0b4e50c3a6a", 0, "6f48b15d-edf1-4858-b499-04a298d9c507", "client69@abv.bg", false, "Alex", "Johnson", false, null, "client69@abv.bg", "client69@abv.bg", "AQAAAAEAACcQAAAAEJsMcO2nKjnOxSycz/cKLofBsSlGTF1Ezm2xWoOwByDYHYBob8AxKFXCyxTW37/seA==", null, false, "", false, "client69@abv.bg" },
                    { "dc449db7-9ae1-4883-89f4-c1504d460853", 0, "326a199d-9c37-4d15-862a-9056fe30f655", "client70@abv.bg", false, "Jack", "Johnson", false, null, "client70@abv.bg", "client70@abv.bg", "AQAAAAEAACcQAAAAEEuAgwOt8ct2nWMZwrutfn/sQxY/ogxaxxoXLn/te2mlItksaKLgXSg1K0vr5GrnSw==", null, false, "", false, "client70@abv.bg" },
                    { "df2fabef-aad9-488e-a542-e6b6c9545b15", 0, "f17fdbba-80dc-4602-a53d-36084baf9d02", "client71@abv.bg", false, "Alex", "Johnson", false, null, "client71@abv.bg", "client71@abv.bg", "AQAAAAEAACcQAAAAEOcQv2w+SGrWv3WJRVod+OjEbg/+nrWzTdHU/egLjEjCNUPbTtZulq3hNqqehOvC9w==", null, false, "", false, "client71@abv.bg" },
                    { "64e50e32-8a7f-4ae0-b679-2d4bc7900d17", 0, "ee72ca95-02ce-424f-9905-cfcb84b300a4", "client72@abv.bg", false, "Alex", "Johnson", false, null, "client72@abv.bg", "client72@abv.bg", "AQAAAAEAACcQAAAAEHD6dOaDWrQvVIZDuGFOfMkFdvGiOgNt8q5Zv4aSpoXLgv/To+uKq5liTl7CIhBeFg==", null, false, "", false, "client72@abv.bg" },
                    { "6ec08e98-7827-4fb1-9de0-191bcf3c1704", 0, "ce72b73e-6eb0-4432-a656-54e3deb76e25", "client57@abv.bg", false, "Jack", "Alexandrov", false, null, "client57@abv.bg", "client57@abv.bg", "AQAAAAEAACcQAAAAEJkfTEk9f2jxtrazlpwf9d2CIUiJ1LS2KmshGkQ9KEMljBAAxewoVf0r5Wccq1l1WA==", null, false, "", false, "client57@abv.bg" },
                    { "9a8f6741-b934-4047-9183-1e846c5c2962", 0, "0185dfec-0277-4b67-a2b4-8b3602a0b2f8", "client56@abv.bg", false, "John", "Alexandrov", false, null, "client56@abv.bg", "client56@abv.bg", "AQAAAAEAACcQAAAAELLN7CloVcJJFVRrjwLmi3MeLvPWhgpy0BmLU2dWf1Jvq2XwhJiEeKJ/p+ABqiSApA==", null, false, "", false, "client56@abv.bg" },
                    { "7edfba5b-255d-48cc-8293-de7f06a022b7", 0, "46284e34-023b-41c8-ab96-eb8100f6a878", "client55@abv.bg", false, "Jane", "Alexandrov", false, null, "client55@abv.bg", "client55@abv.bg", "AQAAAAEAACcQAAAAEFZBdx4NpsQUGYiQReopBYlzffegFfPTV2O7602zR2y/S17BM6fOj7WqrLOad1FG6g==", null, false, "", false, "client55@abv.bg" },
                    { "256f2e87-13cb-4d5f-8b10-b5c3a17e795b", 0, "ee9c01eb-9807-451d-a49c-1b9d458ab46d", "client54@abv.bg", false, "John", "Alexandrov", false, null, "client54@abv.bg", "client54@abv.bg", "AQAAAAEAACcQAAAAEN++NdczDLQzrZRsHXk2w+6kpgP/u3ljcmmcxK40bLOAOYtLl/fCajVyWcHoVArtQg==", null, false, "", false, "client54@abv.bg" },
                    { "033b503e-0fa8-4d11-93f4-52fa1a695347", 0, "db1543c0-a672-467f-8172-02806c6c591c", "client38@abv.bg", false, "Jack", "Johnson", false, null, "client38@abv.bg", "client38@abv.bg", "AQAAAAEAACcQAAAAEFaLb4LMlDeSi4fswaFCKwiF4m4JnHTbC0pUjG9wLDkNyWS67aqktL6qN1yYDLhjuQ==", null, false, "", false, "client38@abv.bg" },
                    { "a5314d7c-fa2e-468d-87b0-a3c5c5aeaee9", 0, "2c0dcb6d-3a73-451c-8544-5e593bf77728", "client39@abv.bg", false, "John", "Alexandrov", false, null, "client39@abv.bg", "client39@abv.bg", "AQAAAAEAACcQAAAAEG6kFDT0LgWy+dsplc0flUHs5j1Y4XoDtnxXtKFAilx3aGniH621eNdkC+DV1LBIPA==", null, false, "", false, "client39@abv.bg" },
                    { "f0a06868-1175-492f-b061-cd8e73ab928f", 0, "d34eb82d-8dff-4234-889d-d55583e74942", "client40@abv.bg", false, "Alex", "Alexandrov", false, null, "client40@abv.bg", "client40@abv.bg", "AQAAAAEAACcQAAAAEN7ANYETynH2pffIdxns6VNh4cqc/do5kKAX6QIdjtnqrj+ADLo2Lr1Upa6KvVEGkA==", null, false, "", false, "client40@abv.bg" },
                    { "b2ff528f-da72-4037-8bd0-f62aa6b7a32a", 0, "4cc35b07-5b01-4378-8d4b-71b905bd4220", "client41@abv.bg", false, "Jane", "Alexandrov", false, null, "client41@abv.bg", "client41@abv.bg", "AQAAAAEAACcQAAAAEPaPr/ei9kuPyCGV+BF/HRLHebdcYQ5un5SHFppJAq76oZrbXkctDYtaIhuxUyqxVA==", null, false, "", false, "client41@abv.bg" },
                    { "3bb6f810-9a29-4374-8d9d-a2a2b4ccbdb3", 0, "b4b4a195-6316-43f3-b126-03ce369f0715", "client42@abv.bg", false, "Jane", "Alexandrov", false, null, "client42@abv.bg", "client42@abv.bg", "AQAAAAEAACcQAAAAEFcBmTH/uYauoHake5NZPzgYE8LbA++7WagIfsXYcW/qbnLPsKlVlfExaHFpJgkzHg==", null, false, "", false, "client42@abv.bg" },
                    { "f9541ab3-e2d1-47d2-8ee0-9edfb08c0838", 0, "8b966fb2-f2ab-41c6-b617-feb88d51dde0", "client43@abv.bg", false, "Jack", "Alexandrov", false, null, "client43@abv.bg", "client43@abv.bg", "AQAAAAEAACcQAAAAEAsi7L/i0O0kjS/9M3SnHPXNhanSPD+AxsYuThDQDQ2z5K65hS9RgnQ6U9kjCMc2bw==", null, false, "", false, "client43@abv.bg" },
                    { "b628ca0e-fb3e-409c-b1cd-8525887063ed", 0, "a29d0ebe-18e8-4187-b7a3-6e6a665c4379", "client44@abv.bg", false, "Jack", "Johnson", false, null, "client44@abv.bg", "client44@abv.bg", "AQAAAAEAACcQAAAAEA6PhOIliLc0kOK/pFN5mRjtAYfN7k3mfEsQteSrWOGhbhmQw9j+pNpRkulNREFFGQ==", null, false, "", false, "client44@abv.bg" },
                    { "9d5922f0-a975-446c-ac70-0a05f88a3158", 0, "dae950fd-66fd-41a1-92b5-08f10d5346dd", "client74@abv.bg", false, "Jane", "Johnson", false, null, "client74@abv.bg", "client74@abv.bg", "AQAAAAEAACcQAAAAEJzWIr/Oa2SQfZgTRonupFoQbX4EBw0JqZKWmDLsxI4iMXOV0zmy36T19F3posDcZQ==", null, false, "", false, "client74@abv.bg" },
                    { "38c8ee62-7138-420c-b8ef-25f88598f9a0", 0, "e1e48d55-f654-42a5-9673-6728ccb9c181", "client45@abv.bg", false, "Jane", "Johnson", false, null, "client45@abv.bg", "client45@abv.bg", "AQAAAAEAACcQAAAAEDlzJnLWbR8cGt55j5gxyYlX9g6F3D1Ldpj+gqgKppYIzXYUorwK74zRUw6udfFfOg==", null, false, "", false, "client45@abv.bg" },
                    { "78b42913-82a4-4e8b-8b29-6fc6993b82af", 0, "a0aa33ce-d75c-4ea4-b6e5-e99118ac5774", "client47@abv.bg", false, "John", "Alexandrov", false, null, "client47@abv.bg", "client47@abv.bg", "AQAAAAEAACcQAAAAEAu9EarW3vWLEok+Gyy+cd4YOWpxzaqCoPuszwoyWu5x5BLBYNyA+2lmvoY0D6k2Hg==", null, false, "", false, "client47@abv.bg" },
                    { "5b0d3b54-a22c-4908-a65f-5bf1f89b457f", 0, "cd5c5e69-9d0d-4c5e-a302-619e28204a81", "client48@abv.bg", false, "Jack", "Alexandrov", false, null, "client48@abv.bg", "client48@abv.bg", "AQAAAAEAACcQAAAAEPlyQfyB4SSsXEuJfTaTEDwULitdgUMxJjUDGEM0PoRYPkpT+93f69RyibUh3ZhNnw==", null, false, "", false, "client48@abv.bg" },
                    { "a0eedfc7-1d83-4e26-bb3a-0053b62d83b4", 0, "cbbd3c5c-6cc1-4207-852c-97b338473f6e", "client49@abv.bg", false, "Alex", "Johnson", false, null, "client49@abv.bg", "client49@abv.bg", "AQAAAAEAACcQAAAAEF8P7LZdhesiMffREWcgXOuZKiiEOUQr9zZ9+y3JCM0g3OJSxv0Mh8iDIJgA9ypojw==", null, false, "", false, "client49@abv.bg" },
                    { "d40aaad2-c6c0-485d-96d2-df57b0acefa6", 0, "923df15d-bd5d-4879-96bd-192bb8689bd0", "client50@abv.bg", false, "John", "Johnson", false, null, "client50@abv.bg", "client50@abv.bg", "AQAAAAEAACcQAAAAEEneSbYLiGfN0lgrPRNtvO6C6dh6nULzLauY4KCPUZHtiOs5gPKRM+lakiELcJXNzQ==", null, false, "", false, "client50@abv.bg" },
                    { "c5f3fd77-62eb-443c-86f5-2e9dbf52e530", 0, "b67796d8-b178-4fbb-9c4f-0e7bb339dd58", "client51@abv.bg", false, "Jack", "Johnson", false, null, "client51@abv.bg", "client51@abv.bg", "AQAAAAEAACcQAAAAECSUBF0VKWIveKl8cWqmH6IeZprazNpxF9SkWMbL+M1evqqF9DCjbdRcMpL5un7n9A==", null, false, "", false, "client51@abv.bg" },
                    { "ab85821a-a06c-4a1d-ac14-3b93b0618a02", 0, "538007f2-8b22-43f7-80f5-7004a0f33cae", "client52@abv.bg", false, "Jack", "Johnson", false, null, "client52@abv.bg", "client52@abv.bg", "AQAAAAEAACcQAAAAEGmcGJRGwHmQYcS1GnyoCN8Pj0pRqlOIomMYLR0FyQ4+ikQ0pqACWke3kV6cyjfANA==", null, false, "", false, "client52@abv.bg" },
                    { "555ce431-4654-4986-8f20-d360f4a74cd8", 0, "512f69ce-5b47-4a04-998a-dab98c0ec840", "client53@abv.bg", false, "Jack", "Johnson", false, null, "client53@abv.bg", "client53@abv.bg", "AQAAAAEAACcQAAAAENT/GNcoLzxwfN1WT2IvuIa5Q3kSNDkpg9eb5O2nE6RfVKynEPpMu7Xk48dE0T+etQ==", null, false, "", false, "client53@abv.bg" },
                    { "0eca25af-1fbc-43d6-8a06-b0c3b5aa5d18", 0, "6d584ed6-8edd-4642-a54f-5bde2efaa19f", "client46@abv.bg", false, "Jane", "Johnson", false, null, "client46@abv.bg", "client46@abv.bg", "AQAAAAEAACcQAAAAEKLxnrCeCmedsovX7iiNAxtY9IS60eFX4WLuc1L7vkGDTFmaVBqLIhZkt62j0BdiJw==", null, false, "", false, "client46@abv.bg" },
                    { "4acb7cae-08e6-44f2-ab88-960d16f403c7", 0, "d5718f08-4d43-4b2c-ac7e-27addbc98d82", "admin@abv.bg", false, "Alex", "Johnson", false, null, "admin@abv.bg", "admin@abv.bg", "AQAAAAEAACcQAAAAEJsRtKYaUIhvnBnHCOmkeDj3sGkhqcVhCNgj1gtZWUGE6Rfdn0i73GBHBZuKTbuQyA==", null, false, "", false, "admin@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "4acb7cae-08e6-44f2-ab88-960d16f403c7", "4da8d4c7-fa79-4f7a-b000-19eda97127db" },
                    { "da6d8b4f-21a7-4d91-9c22-7819103ffac0", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "d6057397-dd38-4fe2-a568-311dbbc8fa0c", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "ba362fb1-911d-4143-af81-77732d55f80e", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "cff7bcdb-dc61-4a52-9de4-aa89cae0e40c", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "894ecb41-0259-48c1-b414-99f57f738380", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "7450dc73-e1a8-4c5f-aaab-821faa7ba1c4", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "51bcbbeb-05be-4c5c-a19a-7bde18e53f3b", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9221af3b-78c1-4ffe-98e9-c06ba3f2cbc6", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "1128dd3d-802d-474d-9be3-20cd8ef27c6d", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "89ae1438-e3c1-4924-add6-288bbb12aa4d", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "1800a1cb-7d0e-4ab4-a56c-0f725fb3974e", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "0e82eb19-b2d2-48ae-864d-aaafa11283f3", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "3a29eea6-67ad-4ca6-a4b6-d0df13f9f80c", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "c31229b8-97ca-4407-b5b3-9c03d9751337", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "c6aa36ed-c85b-4ac1-9728-ba301bc6050e", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "9c59a319-04ad-452d-bc09-124ba8d2d5af", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "f8b23b94-f90c-4c45-9352-d6c4e5607c0c", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9b193e2f-21f1-4677-9b4c-6d18dfe73547", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b1f44b75-b428-4965-abdd-67c8826616fe", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "a3181a1d-ce67-4b52-980d-823a3bf1a8ec", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "5a24df45-4625-44a1-90c5-1540eff277fc", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "1970d163-17a5-4c09-b2dc-344283cfa14e", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "ddfd4dc6-e027-410c-b7c1-52c0aaff7bb2", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "a39533a0-2341-4e6b-b93a-4719db3940c5", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "2150e453-24c2-4074-a426-c9ce7137cc9c", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "6df22645-cfa9-4d97-a69e-9d75673c9335", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "2ee8bdc4-1052-467c-a60e-db8c38f16f98", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "4c1dce67-ff7b-496d-b35c-51d287b60e4f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9ddd665a-3b65-4b2a-94f1-c7f406e32451", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "6af7e72f-354f-4563-9bbb-7298cadc22ab", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "e436ba0e-7633-4ffc-bf06-588f566bd955", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "42d9526a-f9e7-42a3-9713-fc420e2806ca", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b8e156f3-3d76-4f3e-8449-355c20083690", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9671f718-f477-444b-81fe-f55876bb0c4f", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "46a82311-8fa7-48b6-b22b-3b97f47b4d01", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "0e29dad5-2a76-40cc-bfba-6e4140e7bdb6", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "d521400e-bf9d-4dba-bcbb-73a999eb0f0b", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "bcf87598-67e8-40f6-8510-d51aac5ec78c", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "35e6caa5-5f87-4b24-a3f4-005fb222d9c4", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "5f0532b3-e02e-432b-a6f6-498c903ec75c", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "db6abb77-cebe-4a16-bb72-64829baaa9cc", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "bdeaae0c-3ec9-49c6-8a41-53cdb2c758bf", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "7a48e85f-6ddb-4cc4-adee-96108c4fb1e0", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "9a49deaf-a28a-4d91-8b25-77017ef55a86", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "43cc0da6-1564-4abc-82e1-38d5417fe022", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "511337ed-9e27-49ae-a255-8dc0ab159c08", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "891ab165-1375-407d-b89c-8c65d9e71901", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "ae9ed5b4-9107-4423-b0f3-474a7973325c", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "4fa46d5d-9967-4900-b55e-de197a550347", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "caaaba6b-317a-4d0f-9052-06232b8fd021", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "69b8b5cf-dc0f-4e15-8c30-d2937070c1cb", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "2261ba61-97df-41f8-80b4-25cec5383a94", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "6c7c6fdc-99e7-484a-9391-c1bbdc35660e", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "1c353b70-bbc1-4702-a786-7fe4a4e4dfc4", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "5d1ed47a-6fea-4eb0-ba14-1e02ed752cf5", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "22345e60-eb29-408f-ae2e-c09a15d03667", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "a0b7f711-2bf3-4477-8dd8-4056810c6120", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "f5121409-9aad-4dd0-863a-8253bb36898a", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "86407c75-8966-4f49-96e0-549ac0f1b00c", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "23af98bd-1efe-423f-9e53-4000faf44345", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "6482957f-57f1-4dd9-9ea2-6a9bef20d208", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "43d137ed-c8bf-4547-abdc-b34bae1e9534", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "20df404a-a19d-44fc-83cf-0464e249fb66", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "7fda7c7c-ef19-4c51-a493-edc5de0cee24", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "2caba972-7562-481b-8074-f8a58d50c4f8", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "0bb9c8f6-30b4-4185-8f06-83f4f1741d19", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "c73b658f-c3aa-4297-96d9-0a22b2f395fb", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "59717167-f1f3-4327-bfcc-029fc3bf7447", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "d95d271a-ff11-426b-b21f-c6e1b67876cb", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "4750d1c7-88d6-4d46-a408-cf00338029a4", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "460d59db-bfef-4497-b90b-00bd6bfbecde", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "c264e5cb-ac77-422a-b9ae-66e45f45cff8", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "7fe0425d-a5c7-41cb-a659-6624fb8ab1d3", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "7c60bad0-cb6a-4126-8106-c929941c630b", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "2da86768-7f07-4f55-83a1-ad248ee5a9ec", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9ecd7ee4-efc4-43fc-94e3-7c089c19eaa5", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "3858e5b2-5a9c-4e2f-9c45-60b97bfaf369", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "8f1b7530-7517-436f-a344-d2bdb711eda8", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "4a2c08d3-6813-473c-a0b6-d96e25e4049f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9d5922f0-a975-446c-ac70-0a05f88a3158", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "f369707c-405a-453b-ad2d-e2902a2fcd9a", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "64e50e32-8a7f-4ae0-b679-2d4bc7900d17", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "df2fabef-aad9-488e-a542-e6b6c9545b15", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "dc449db7-9ae1-4883-89f4-c1504d460853", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "0899c3a0-43f4-4d32-8429-d0b4e50c3a6a", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "4cf8d15a-256e-4eb0-8507-f9c27dae147f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "70ec08e2-0915-4105-a9af-9b0d8e509811", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "df8c7835-859b-4bda-acfb-c026e9476081", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "09f5f987-7fa7-4464-8afd-65796b472e76", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "8c519f2e-a0cf-4e76-99f4-f2cc39d0e9f0", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "edec9150-ad25-4dcc-bebe-2d33f232039d", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "d340d8f7-30a4-420f-b536-7eacea7bc672", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "61f1bd78-0d67-4d74-8727-eb10a8146f80", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "1a5567a6-ebc4-456c-9b5f-5ce1851b43c7", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "cf80f72e-9a31-4bd8-b16d-67516dacaa3b", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "05218c2d-5f75-432f-ad79-026caa146ef8", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "276d3d90-6edf-4421-94e3-602b1358e8b4", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b27926f4-2084-49a1-aee8-b0c5976ef21b", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "47012b59-c03c-4d5b-b19d-a56620f2fdcc", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "90e4fa2c-68ff-45c9-b381-ad09cd9d9572", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "e32675aa-edae-4442-9ade-0ef56d5be33d", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "21b06bfd-89be-4c6f-a786-df1370423986", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "5e7b5b8a-0af6-4839-b18b-f19f151e2eec", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "dd8f1cef-b20d-46ab-bb0c-f030b8154e54", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9e7e0e5c-113c-40c1-90d3-e398460219ea", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b508a744-e79f-4efc-b970-eaa6a3281646", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "e983658e-5955-4713-b859-edb1bd35dcad", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "7b3c3e29-3043-46a6-91d8-a2e835bca47c", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "96c349b3-ba57-4c23-b107-508fb365c593", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "410d44e2-a3df-4189-a1c6-8b2dccf6288b", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "a46a5db1-98cf-48b8-821f-1ab8ca82d410", "92d8da87-ed58-47ff-b3b3-3e8348d8a956" },
                    { "b4d0bd84-6fc4-4f7d-9cd2-9b7e42ef8ee5", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9bbb17ad-2682-499b-8259-3f3983afa7db", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "f0a06868-1175-492f-b061-cd8e73ab928f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "a5314d7c-fa2e-468d-87b0-a3c5c5aeaee9", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "033b503e-0fa8-4d11-93f4-52fa1a695347", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "4ba477a8-77df-4152-8884-2a7db6f6a09f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "33d89876-87f5-4bd9-a132-35d7644a1ace", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "3ef1ef9e-efa5-475f-b79e-92a5b16a2fe8", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "01487671-e41c-467e-8528-1cbff7ef05a9", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "dc8053f3-07e9-47b2-9881-85978619f8da", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "7637299f-cc9d-4a66-9b99-80fc96a8c35f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b462a280-c82e-4c83-8df9-777b87a541d2", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b5663631-94d3-4c44-b500-09cb126f081a", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b463d853-37fa-43c5-80a8-050fff6a258a", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "6e7f9b7b-1bcc-4e7a-b59a-58feecbfa386", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b08bda2c-ddd1-4a5f-8fe2-fdaad28dff64", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "4ba63feb-16e6-4c94-837f-c99463b32ecb", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b2ff528f-da72-4037-8bd0-f62aa6b7a32a", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9ec037f3-e405-4bb8-816a-5d1e3dd54fbd", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "3bb6f810-9a29-4374-8d9d-a2a2b4ccbdb3", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "b628ca0e-fb3e-409c-b1cd-8525887063ed", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "3b925854-48ae-4896-ae37-eb2c772424f2", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "540f0939-b07d-4488-b473-a668dea18858", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "6ec08e98-7827-4fb1-9de0-191bcf3c1704", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "9a8f6741-b934-4047-9183-1e846c5c2962", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "7edfba5b-255d-48cc-8293-de7f06a022b7", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "256f2e87-13cb-4d5f-8b10-b5c3a17e795b", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "555ce431-4654-4986-8f20-d360f4a74cd8", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "ab85821a-a06c-4a1d-ac14-3b93b0618a02", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "c5f3fd77-62eb-443c-86f5-2e9dbf52e530", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "d40aaad2-c6c0-485d-96d2-df57b0acefa6", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "a0eedfc7-1d83-4e26-bb3a-0053b62d83b4", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "5b0d3b54-a22c-4908-a65f-5bf1f89b457f", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "78b42913-82a4-4e8b-8b29-6fc6993b82af", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "0eca25af-1fbc-43d6-8a06-b0c3b5aa5d18", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "38c8ee62-7138-420c-b8ef-25f88598f9a0", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "f9541ab3-e2d1-47d2-8ee0-9edfb08c0838", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "dca26712-f4c7-440a-85bf-7aa0adba523a", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" },
                    { "4cf07cd3-f413-4406-9794-256bd1c8e429", "fc899ee2-c5d0-4de5-bd06-0c08f1ec2c60" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { "705bfb3a-b72e-42e2-8520-6026a1b4755b", "9d5922f0-a975-446c-ac70-0a05f88a3158" },
                    { "45499b9e-b1a3-4465-b2e5-30118717b9f7", "ab85821a-a06c-4a1d-ac14-3b93b0618a02" },
                    { "25c7dbd8-241d-4127-9efe-0dd605fda87a", "c5f3fd77-62eb-443c-86f5-2e9dbf52e530" },
                    { "c423c269-9477-4cdb-9afe-00f92951e9a2", "d40aaad2-c6c0-485d-96d2-df57b0acefa6" },
                    { "d8728bbe-9b13-4f28-8bca-9908101c5a38", "a0eedfc7-1d83-4e26-bb3a-0053b62d83b4" },
                    { "29fe01db-203c-4298-94cf-d13db4073e11", "5b0d3b54-a22c-4908-a65f-5bf1f89b457f" },
                    { "24f22f41-d199-4571-926a-c26f3a3670b5", "78b42913-82a4-4e8b-8b29-6fc6993b82af" },
                    { "c507ebfe-7f6b-49ac-84e3-6b666c487eb2", "555ce431-4654-4986-8f20-d360f4a74cd8" },
                    { "93b9ba67-d49b-44d2-8dcf-d5b21f38a8ad", "0eca25af-1fbc-43d6-8a06-b0c3b5aa5d18" },
                    { "0d515028-4bb6-4a24-94ed-2ade25c53fc8", "b628ca0e-fb3e-409c-b1cd-8525887063ed" },
                    { "3106a050-6683-4dca-b999-cbc2fe72259c", "f9541ab3-e2d1-47d2-8ee0-9edfb08c0838" },
                    { "915cdee7-6e27-4d9f-8cad-3df520c3d1c1", "3bb6f810-9a29-4374-8d9d-a2a2b4ccbdb3" },
                    { "3fb55317-553d-4ca8-9d1f-03db8bd468b4", "b2ff528f-da72-4037-8bd0-f62aa6b7a32a" },
                    { "12e625da-864f-41e4-aba3-86f8e20d2fa2", "f0a06868-1175-492f-b061-cd8e73ab928f" },
                    { "7d2ba176-4760-4b0d-ac04-4f5ba79bd634", "a5314d7c-fa2e-468d-87b0-a3c5c5aeaee9" },
                    { "be0096a5-d2e9-4ef5-b1b2-f98d43539aaa", "38c8ee62-7138-420c-b8ef-25f88598f9a0" },
                    { "a1d6ae09-ee04-4c66-8bbc-3ac3101ee31e", "256f2e87-13cb-4d5f-8b10-b5c3a17e795b" },
                    { "7a13f599-4aa8-49f5-be79-b1e1aa9fab14", "7edfba5b-255d-48cc-8293-de7f06a022b7" },
                    { "b91d5a57-dd37-4200-921d-450ebfa6b3f8", "9a8f6741-b934-4047-9183-1e846c5c2962" },
                    { "504bc63f-6523-4646-9efa-05467efda3ed", "df2fabef-aad9-488e-a542-e6b6c9545b15" },
                    { "85b70363-6d98-4bec-b01d-93b5adaaefff", "dc449db7-9ae1-4883-89f4-c1504d460853" },
                    { "bea46603-45a6-41fa-8fe9-0916b8b62048", "0899c3a0-43f4-4d32-8429-d0b4e50c3a6a" },
                    { "4971054f-438d-44f4-b5f7-c88f60292406", "4cf8d15a-256e-4eb0-8507-f9c27dae147f" },
                    { "0b43aa02-7b8e-4aed-8797-713f9a591ef6", "70ec08e2-0915-4105-a9af-9b0d8e509811" },
                    { "56f71cf0-d3fe-4ab2-8c37-e248e9899d1e", "df8c7835-859b-4bda-acfb-c026e9476081" },
                    { "a45a9e6e-5dc4-4f0d-a69b-a3002be81155", "09f5f987-7fa7-4464-8afd-65796b472e76" },
                    { "872b9597-0a63-4097-ad4a-0e0f99bf9341", "8c519f2e-a0cf-4e76-99f4-f2cc39d0e9f0" },
                    { "ebc9fe78-024b-48f7-a6df-0cb8c7fb22e3", "d340d8f7-30a4-420f-b536-7eacea7bc672" },
                    { "2d5ddfd5-f214-4155-8747-e18c33df7264", "b4d0bd84-6fc4-4f7d-9cd2-9b7e42ef8ee5" },
                    { "8f370381-58f3-4a3b-9b89-8172583c8187", "9ec037f3-e405-4bb8-816a-5d1e3dd54fbd" },
                    { "230eefca-f093-4883-ad23-5981162a011c", "9bbb17ad-2682-499b-8259-3f3983afa7db" },
                    { "6cbdd63a-2696-49f4-a63a-52ab7782f156", "3b925854-48ae-4896-ae37-eb2c772424f2" },
                    { "860e9c3b-7535-45f2-9140-a083c03213bc", "540f0939-b07d-4488-b473-a668dea18858" },
                    { "d7d3b30b-0a46-439e-841a-574640297ef0", "6ec08e98-7827-4fb1-9de0-191bcf3c1704" },
                    { "a590b3f1-5dd4-4125-91bd-451049042b34", "033b503e-0fa8-4d11-93f4-52fa1a695347" },
                    { "b144e6d7-5a49-48d3-8602-783fe88d7382", "4ba477a8-77df-4152-8884-2a7db6f6a09f" },
                    { "d14ba8fd-b815-4e3b-83a7-ba49df9e0efc", "33d89876-87f5-4bd9-a132-35d7644a1ace" },
                    { "df32a4ee-d79e-4b59-9e17-0151a584de4b", "3ef1ef9e-efa5-475f-b79e-92a5b16a2fe8" },
                    { "5b3bcc8c-189e-4345-9734-7859ad9b789c", "2150e453-24c2-4074-a426-c9ce7137cc9c" },
                    { "4ff204b3-2fa4-42b9-a7a7-88db8eba903c", "6df22645-cfa9-4d97-a69e-9d75673c9335" },
                    { "87e84006-f1df-4f10-9344-6b48b6d3618a", "2ee8bdc4-1052-467c-a60e-db8c38f16f98" },
                    { "fd002a7b-3472-4c7b-b353-38ac77fb88cc", "4c1dce67-ff7b-496d-b35c-51d287b60e4f" },
                    { "e96cf2c3-f999-413c-ad55-35f32ed28d74", "9ddd665a-3b65-4b2a-94f1-c7f406e32451" },
                    { "d9d6c4f4-17ce-4e6c-bdaa-2516183fcc41", "6af7e72f-354f-4563-9bbb-7298cadc22ab" },
                    { "95aeb9f5-6bbf-4e4a-b80d-f465159cf8eb", "e436ba0e-7633-4ffc-bf06-588f566bd955" },
                    { "fea60626-39ac-4e8b-9d3a-cb4ec2ef06fb", "42d9526a-f9e7-42a3-9713-fc420e2806ca" },
                    { "c211071b-2cf5-4f99-b837-74a6320bbadf", "b8e156f3-3d76-4f3e-8449-355c20083690" },
                    { "11becfc4-f614-4402-b04a-d6e31f706d6e", "9b193e2f-21f1-4677-9b4c-6d18dfe73547" },
                    { "85246603-8d85-4b2c-bd10-217e4774ca75", "f8b23b94-f90c-4c45-9352-d6c4e5607c0c" },
                    { "d95b68d0-b749-4ebb-b8ef-dff350a39952", "9c59a319-04ad-452d-bc09-124ba8d2d5af" },
                    { "ba96925b-9a72-44ed-b7b1-ff1da59fa484", "51bcbbeb-05be-4c5c-a19a-7bde18e53f3b" },
                    { "9e0853b6-4012-45dd-97b9-7ad4bc3e3215", "da6d8b4f-21a7-4d91-9c22-7819103ffac0" },
                    { "5eb9dc34-d536-4b52-9625-25f643f0b301", "d6057397-dd38-4fe2-a568-311dbbc8fa0c" },
                    { "6c9e19aa-af56-49ff-90ac-acd17c95b2d4", "a39533a0-2341-4e6b-b93a-4719db3940c5" },
                    { "c83a086e-217c-48f2-aada-f6cfa837ff41", "64e50e32-8a7f-4ae0-b679-2d4bc7900d17" },
                    { "19109bde-9dad-4ed3-ae91-744611171498", "ddfd4dc6-e027-410c-b7c1-52c0aaff7bb2" },
                    { "1536711b-ba8d-45cb-8bac-9a9e3aca3d28", "5a24df45-4625-44a1-90c5-1540eff277fc" },
                    { "0b2d2f62-3867-407c-b356-6fbcaf6e6422", "01487671-e41c-467e-8528-1cbff7ef05a9" },
                    { "ce4bbb99-8f0e-4ba0-a5d0-39f4791f0094", "dc8053f3-07e9-47b2-9881-85978619f8da" },
                    { "d363f0d6-3f42-4998-966c-c2a9add1f485", "7637299f-cc9d-4a66-9b99-80fc96a8c35f" },
                    { "19029ed8-6343-49dc-a910-fbc17075ec43", "b462a280-c82e-4c83-8df9-777b87a541d2" },
                    { "c16dad0f-3504-4d35-b0d6-6a4cacf66785", "b5663631-94d3-4c44-b500-09cb126f081a" },
                    { "2220d804-f1df-4201-a4f8-41c6b01ce5e7", "b463d853-37fa-43c5-80a8-050fff6a258a" },
                    { "585d55ed-53c0-4470-a962-21365c0d2a23", "6e7f9b7b-1bcc-4e7a-b59a-58feecbfa386" },
                    { "8146c167-020b-42fa-a748-5d432a391bf5", "b08bda2c-ddd1-4a5f-8fe2-fdaad28dff64" },
                    { "19a7f865-5e39-4bfc-a2df-65c597ac151e", "4ba63feb-16e6-4c94-837f-c99463b32ecb" },
                    { "81dad6aa-8890-44e8-820b-9cfe1f1c0702", "2da86768-7f07-4f55-83a1-ad248ee5a9ec" },
                    { "1c156afc-7a3d-4add-995a-010060dcf12b", "7c60bad0-cb6a-4126-8106-c929941c630b" },
                    { "97643c25-2123-4c06-8a23-74ee6546ef79", "7fe0425d-a5c7-41cb-a659-6624fb8ab1d3" },
                    { "a0518fcb-95ed-4b8e-8609-dffd5a03ebd4", "1c353b70-bbc1-4702-a786-7fe4a4e4dfc4" },
                    { "7e067ff1-8be4-482b-890e-5c6c107db4d7", "b1f44b75-b428-4965-abdd-67c8826616fe" },
                    { "e7ae71a8-c58a-47b9-a067-f5724f904053", "a3181a1d-ce67-4b52-980d-823a3bf1a8ec" },
                    { "f86ef1aa-cbac-4ce3-8ebb-21079a8cfb30", "1970d163-17a5-4c09-b2dc-344283cfa14e" },
                    { "e1fc965d-3cc0-4c28-bf75-d7b4e77813d4", "f369707c-405a-453b-ad2d-e2902a2fcd9a" },
                    { "f2d9df9b-1566-4f1d-b8c5-9df500db2257", "ba362fb1-911d-4143-af81-77732d55f80e" },
                    { "639bfc98-d4bb-4dd2-87bf-5220db72b44e", "4a2c08d3-6813-473c-a0b6-d96e25e4049f" },
                    { "6eb9817d-615b-4c17-bb11-17fb5057ed65", "dca26712-f4c7-440a-85bf-7aa0adba523a" },
                    { "bba40aab-2a32-4900-916d-a21d5c247120", "cf80f72e-9a31-4bd8-b16d-67516dacaa3b" },
                    { "99265e62-308e-4141-89b6-64263b8b87da", "05218c2d-5f75-432f-ad79-026caa146ef8" },
                    { "3f8c7bae-5237-4ef2-8be4-774919eb00e3", "276d3d90-6edf-4421-94e3-602b1358e8b4" },
                    { "7da2d327-831e-4c0a-bb4f-efc21ec36c37", "b27926f4-2084-49a1-aee8-b0c5976ef21b" },
                    { "9954f9d2-34e0-42fb-a4fd-fe1f2078fea7", "47012b59-c03c-4d5b-b19d-a56620f2fdcc" },
                    { "2d3b0cd1-46a0-4de1-83c6-a3dd8a95f405", "90e4fa2c-68ff-45c9-b381-ad09cd9d9572" },
                    { "ffdfb60e-8928-4ba3-a579-ce7a939ba3ab", "e32675aa-edae-4442-9ade-0ef56d5be33d" },
                    { "bd81076d-5c05-402f-a256-8199aecbb14a", "21b06bfd-89be-4c6f-a786-df1370423986" },
                    { "e8a0c408-e58a-41ba-ac5c-5a1c14a4e848", "5e7b5b8a-0af6-4839-b18b-f19f151e2eec" },
                    { "053f8318-7a0b-4f0d-a288-4d4f054863d4", "dd8f1cef-b20d-46ab-bb0c-f030b8154e54" },
                    { "aebe648d-eed6-4a26-9b11-3033b9d55af8", "4cf07cd3-f413-4406-9794-256bd1c8e429" },
                    { "2362e38f-d730-43e0-951a-4b28d2d38a84", "b508a744-e79f-4efc-b970-eaa6a3281646" },
                    { "96314c97-f85c-44f1-97e6-5d9bd2a41ed2", "e983658e-5955-4713-b859-edb1bd35dcad" },
                    { "858eccd2-6a4a-4593-b6b5-e4552c491390", "7b3c3e29-3043-46a6-91d8-a2e835bca47c" },
                    { "6680951f-65b2-446c-b1de-3f8ae68322d0", "96c349b3-ba57-4c23-b107-508fb365c593" },
                    { "64006685-eb21-4dcd-8446-c6adb4e03f9c", "1a5567a6-ebc4-456c-9b5f-5ce1851b43c7" },
                    { "35ba3d39-8cd2-4ce3-8685-e8097b7b0450", "410d44e2-a3df-4189-a1c6-8b2dccf6288b" },
                    { "6ec3d77f-d3b2-44ce-9ece-6e5df5bf59bb", "61f1bd78-0d67-4d74-8727-eb10a8146f80" },
                    { "80524ea0-aac4-40e2-b3d4-01b182d9924b", "edec9150-ad25-4dcc-bebe-2d33f232039d" },
                    { "608fe955-53c9-40cd-b4e5-27c59cecb772", "9ecd7ee4-efc4-43fc-94e3-7c089c19eaa5" },
                    { "70bc7403-32ea-461b-ab20-07120b63e9ac", "3858e5b2-5a9c-4e2f-9c45-60b97bfaf369" },
                    { "55a97bcd-5ae6-4a80-a76d-91e3a0db3856", "8f1b7530-7517-436f-a344-d2bdb711eda8" },
                    { "8c0f3fcb-950a-4282-9e56-78e92c898b5f", "9e7e0e5c-113c-40c1-90d3-e398460219ea" }
                });

            migrationBuilder.InsertData(
                table: "Housekeepers",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { "d805c416-b037-4cdc-957b-78204cb46946", "a0b7f711-2bf3-4477-8dd8-4056810c6120" },
                    { "8bd0640c-d44b-4246-b37b-fa6d84922bb9", "f5121409-9aad-4dd0-863a-8253bb36898a" },
                    { "95238d1c-6b3f-4c34-a12d-095c079a6757", "86407c75-8966-4f49-96e0-549ac0f1b00c" },
                    { "14491590-219f-40d6-9d66-2ae89a08f9ab", "23af98bd-1efe-423f-9e53-4000faf44345" },
                    { "2fcdd492-a2cd-44d8-ab31-1e1117fc01e3", "2caba972-7562-481b-8074-f8a58d50c4f8" },
                    { "df2742cf-65c1-417f-8ef6-258fb3758119", "43d137ed-c8bf-4547-abdc-b34bae1e9534" },
                    { "e76af301-5e87-462e-ab85-78f41f71b63a", "20df404a-a19d-44fc-83cf-0464e249fb66" },
                    { "90c5f93b-e938-42b5-9151-e3c4ab98d75e", "7fda7c7c-ef19-4c51-a493-edc5de0cee24" },
                    { "867678ca-7f73-4d4f-84ae-d4ee3cb28137", "d521400e-bf9d-4dba-bcbb-73a999eb0f0b" },
                    { "9a873f2b-5d04-45b9-97cc-78c458bce005", "6482957f-57f1-4dd9-9ea2-6a9bef20d208" },
                    { "5e89518d-c9d2-4ef1-acf4-c0bca04d9ca3", "0e29dad5-2a76-40cc-bfba-6e4140e7bdb6" },
                    { "ea74e487-fd9d-4c0a-a539-73bfabaec6c0", "1800a1cb-7d0e-4ab4-a56c-0f725fb3974e" },
                    { "f38666b6-dce1-490e-9328-affd326ded53", "9671f718-f477-444b-81fe-f55876bb0c4f" },
                    { "50d90dd3-a6c3-4261-b105-1f4269ae245d", "c31229b8-97ca-4407-b5b3-9c03d9751337" },
                    { "1a8eacd7-ae74-4066-94f6-dd6f1fe2bf1d", "3a29eea6-67ad-4ca6-a4b6-d0df13f9f80c" },
                    { "d3eb099e-ecfd-4bcc-9b33-dae3fafde8c1", "0e82eb19-b2d2-48ae-864d-aaafa11283f3" },
                    { "7faf9b82-c37a-4601-9b91-a658e895e5f7", "89ae1438-e3c1-4924-add6-288bbb12aa4d" },
                    { "7ea0c459-0a47-4542-a8fd-5fbabbb9a23b", "1128dd3d-802d-474d-9be3-20cd8ef27c6d" },
                    { "cc1f7051-8ca7-4d73-8211-8631e77268ab", "c6aa36ed-c85b-4ac1-9728-ba301bc6050e" },
                    { "7b8c32f4-758f-484e-9f51-6c015a856d6b", "9221af3b-78c1-4ffe-98e9-c06ba3f2cbc6" },
                    { "c3fd55b6-faed-4f62-95e6-1157644b0ad4", "7450dc73-e1a8-4c5f-aaab-821faa7ba1c4" },
                    { "166807b2-d370-4ee6-bc42-b64f3bb72b5e", "0bb9c8f6-30b4-4185-8f06-83f4f1741d19" },
                    { "4c6293df-9961-4706-9d20-d15cdabef007", "46a82311-8fa7-48b6-b22b-3b97f47b4d01" },
                    { "e1d06852-8317-4ba1-838b-704442665bde", "c73b658f-c3aa-4297-96d9-0a22b2f395fb" },
                    { "5fa58adb-e8bf-4298-b4d6-5ba8da18cf11", "db6abb77-cebe-4a16-bb72-64829baaa9cc" },
                    { "2c830172-1514-4aab-a3f9-a54a8ab3ed94", "d95d271a-ff11-426b-b21f-c6e1b67876cb" },
                    { "a0c9ebb2-b175-4457-bb81-17c257d0b423", "a46a5db1-98cf-48b8-821f-1ab8ca82d410" },
                    { "371dabe4-95c1-44a0-aff2-8cfc7d530e35", "2261ba61-97df-41f8-80b4-25cec5383a94" },
                    { "a54ca9b3-496c-4374-8388-153afe770aec", "69b8b5cf-dc0f-4e15-8c30-d2937070c1cb" },
                    { "abcc141b-6be5-4b46-a7b7-94910e129f00", "caaaba6b-317a-4d0f-9052-06232b8fd021" },
                    { "3f08cc20-1e06-4c64-a654-fd4d2b1c39b7", "4fa46d5d-9967-4900-b55e-de197a550347" },
                    { "6031f8ad-1e29-4815-bc43-8eea01874bc0", "ae9ed5b4-9107-4423-b0f3-474a7973325c" },
                    { "e84920c6-7457-4c11-9121-c1681325fb5d", "891ab165-1375-407d-b89c-8c65d9e71901" },
                    { "3ad95c26-d87f-4032-b9d6-73eca3d1dbe0", "511337ed-9e27-49ae-a255-8dc0ab159c08" },
                    { "067f6b6b-cb41-4965-8618-31619b0e5524", "43cc0da6-1564-4abc-82e1-38d5417fe022" },
                    { "01ac2dfa-c94a-46d2-8603-5b17e2a41f3f", "9a49deaf-a28a-4d91-8b25-77017ef55a86" },
                    { "de500829-d8d3-4da9-a184-65626b518a79", "59717167-f1f3-4327-bfcc-029fc3bf7447" },
                    { "8bae9dc7-7750-4f0d-9aa2-c027ad46e07a", "7a48e85f-6ddb-4cc4-adee-96108c4fb1e0" },
                    { "21bfc32f-bfb2-4bc5-bebf-d40561d85e9a", "cff7bcdb-dc61-4a52-9de4-aa89cae0e40c" },
                    { "356308ab-aadd-4666-9461-baf8dcab806f", "5f0532b3-e02e-432b-a6f6-498c903ec75c" },
                    { "6ae6e243-447e-4360-9817-d19034827492", "35e6caa5-5f87-4b24-a3f4-005fb222d9c4" },
                    { "c87d0330-3a7e-440f-9719-97cd0c9e096f", "bcf87598-67e8-40f6-8510-d51aac5ec78c" },
                    { "1538a081-8eac-4c38-86d3-533e8cc5c704", "6c7c6fdc-99e7-484a-9391-c1bbdc35660e" },
                    { "a61c476e-c398-4aba-9ba9-620bf83e9c82", "5d1ed47a-6fea-4eb0-ba14-1e02ed752cf5" },
                    { "42443199-b64d-4093-9174-7830c295b5c9", "c264e5cb-ac77-422a-b9ae-66e45f45cff8" },
                    { "ac9748f3-9d9f-4143-aaee-7829ba9db218", "22345e60-eb29-408f-ae2e-c09a15d03667" },
                    { "e81180ec-cc20-47a8-830a-079e1dcbd0e2", "460d59db-bfef-4497-b90b-00bd6bfbecde" },
                    { "a4f89efc-b278-4db9-aa1f-1a85a065f209", "4750d1c7-88d6-4d46-a408-cf00338029a4" },
                    { "356446e1-4c40-4954-b9db-34710168e5f4", "bdeaae0c-3ec9-49c6-8a41-53cdb2c758bf" },
                    { "cbc02226-702a-406c-a7ea-db535e534e77", "894ecb41-0259-48c1-b414-99f57f738380" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Housekeepers_UserId",
                table: "Housekeepers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClientId",
                table: "Locations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientId",
                table: "Requests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_HousekeeperId",
                table: "Requests",
                column: "HousekeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LocationId",
                table: "Requests",
                column: "LocationId");
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
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Housekeepers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
