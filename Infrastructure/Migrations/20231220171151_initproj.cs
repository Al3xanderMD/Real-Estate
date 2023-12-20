using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initproj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    AddressName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CommercialCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partitionings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partitionings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasePosts",
                columns: table => new
                {
                    BasePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TitlePost = table.Column<string>(type: "text", nullable: false),
                    Images = table.Column<List<string>>(type: "text[]", nullable: false),
                    OfferType = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePosts", x => x.BasePostId);
                    table.ForeignKey(
                        name: "FK_BasePosts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialSpecifics",
                columns: table => new
                {
                    CommercialSpecificId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificName = table.Column<string>(type: "text", nullable: false),
                    CommercialCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialSpecifics", x => x.CommercialSpecificId);
                    table.ForeignKey(
                        name: "FK_CommercialSpecifics_CommercialCategories_CommercialCategory~",
                        column: x => x.CommercialCategoryId,
                        principalTable: "CommercialCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    BasePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomCount = table.Column<int>(type: "integer", nullable: false),
                    PartitioningId = table.Column<Guid>(type: "uuid", nullable: false),
                    Comfort = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    UsefulSurface = table.Column<double>(type: "double precision", nullable: false),
                    BuildYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.BasePostId);
                    table.ForeignKey(
                        name: "FK_Apartments_BasePosts_BasePostId",
                        column: x => x.BasePostId,
                        principalTable: "BasePosts",
                        principalColumn: "BasePostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartments_Partitionings_PartitioningId",
                        column: x => x.PartitioningId,
                        principalTable: "Partitionings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelPensions",
                columns: table => new
                {
                    BasePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsefulSurface = table.Column<double>(type: "double precision", nullable: false),
                    RoomSurface = table.Column<double>(type: "double precision", nullable: false),
                    RoomCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelPensions", x => x.BasePostId);
                    table.ForeignKey(
                        name: "FK_HotelPensions_BasePosts_BasePostId",
                        column: x => x.BasePostId,
                        principalTable: "BasePosts",
                        principalColumn: "BasePostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    BasePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomCount = table.Column<int>(type: "integer", nullable: false),
                    HouseTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Comfort = table.Column<int>(type: "integer", nullable: false),
                    FloorCount = table.Column<int>(type: "integer", nullable: false),
                    UsefulSurface = table.Column<double>(type: "double precision", nullable: false),
                    LotArea = table.Column<double>(type: "double precision", nullable: false),
                    BuildYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.BasePostId);
                    table.ForeignKey(
                        name: "FK_Houses_BasePosts_BasePostId",
                        column: x => x.BasePostId,
                        principalTable: "BasePosts",
                        principalColumn: "BasePostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_HouseTypes_HouseTypeId",
                        column: x => x.HouseTypeId,
                        principalTable: "HouseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    BasePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    LotClassificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LotArea = table.Column<double>(type: "double precision", nullable: false),
                    StreetFrontage = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.BasePostId);
                    table.ForeignKey(
                        name: "FK_Lots_BasePosts_BasePostId",
                        column: x => x.BasePostId,
                        principalTable: "BasePosts",
                        principalColumn: "BasePostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_LotClassifications_LotClassificationId",
                        column: x => x.LotClassificationId,
                        principalTable: "LotClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commercials",
                columns: table => new
                {
                    BasePostId = table.Column<Guid>(type: "uuid", nullable: false),
                    CommercialSpecificId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsefulSurface = table.Column<double>(type: "double precision", nullable: false),
                    Disponibility = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commercials", x => x.BasePostId);
                    table.ForeignKey(
                        name: "FK_Commercials_BasePosts_BasePostId",
                        column: x => x.BasePostId,
                        principalTable: "BasePosts",
                        principalColumn: "BasePostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commercials_CommercialSpecifics_CommercialSpecificId",
                        column: x => x.CommercialSpecificId,
                        principalTable: "CommercialSpecifics",
                        principalColumn: "CommercialSpecificId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_PartitioningId",
                table: "Apartments",
                column: "PartitioningId");

            migrationBuilder.CreateIndex(
                name: "IX_BasePosts_AddressId",
                table: "BasePosts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Commercials_CommercialSpecificId",
                table: "Commercials",
                column: "CommercialSpecificId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialSpecifics_CommercialCategoryId",
                table: "CommercialSpecifics",
                column: "CommercialCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseTypeId",
                table: "Houses",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LotClassificationId",
                table: "Lots",
                column: "LotClassificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Commercials");

            migrationBuilder.DropTable(
                name: "HotelPensions");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Partitionings");

            migrationBuilder.DropTable(
                name: "CommercialSpecifics");

            migrationBuilder.DropTable(
                name: "HouseTypes");

            migrationBuilder.DropTable(
                name: "BasePosts");

            migrationBuilder.DropTable(
                name: "LotClassifications");

            migrationBuilder.DropTable(
                name: "CommercialCategories");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
