using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeJail.App.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AnimeJailDb");

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Article_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleStatus",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ArticleStatus_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Country_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "JailType",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JailType_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPostion",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WorkPostion_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    countryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Region_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Region_countryId_fkey",
                        column: x => x.countryId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Jail",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: true),
                    typeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Jail_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Jail_typeId_fkey",
                        column: x => x.typeId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "JailType",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    regionId = table.Column<int>(type: "integer", nullable: true),
                    countryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("City_pkey", x => x.id);
                    table.ForeignKey(
                        name: "City_countryId_fkey",
                        column: x => x.countryId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Country",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "City_regionId_fkey",
                        column: x => x.regionId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Region",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    cityId = table.Column<int>(type: "integer", nullable: false),
                    streetName = table.Column<string>(type: "text", nullable: false),
                    buildingNumber = table.Column<string>(type: "text", nullable: true),
                    apartmentNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Address_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Address_cityId_fkey",
                        column: x => x.cityId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "City",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PassportData",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    issueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    domiclleRegistrationAdressId = table.Column<int>(type: "integer", nullable: true),
                    serial = table.Column<int>(type: "integer", nullable: true),
                    number = table.Column<int>(type: "integer", nullable: false),
                    issuingCountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PassportData_pkey", x => x.id);
                    table.ForeignKey(
                        name: "PassportData_domiclleRegistrationAdressId_fkey",
                        column: x => x.domiclleRegistrationAdressId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "PassportData_issuingCountryId_fkey",
                        column: x => x.issuingCountryId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Country",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    secondName = table.Column<string>(type: "text", nullable: false),
                    middleName = table.Column<string>(type: "text", nullable: true),
                    workPositionId = table.Column<int>(type: "integer", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    phoneNumber = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    hiredate = table.Column<DateOnly>(type: "date", nullable: false),
                    dismdate = table.Column<DateOnly>(type: "date", nullable: true),
                    passportId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Employee_passportId_fkey",
                        column: x => x.passportId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "PassportData",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Employee_workPositionId_fkey",
                        column: x => x.workPositionId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "WorkPostion",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Prisoner",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    secondName = table.Column<string>(type: "text", nullable: false),
                    middleName = table.Column<string>(type: "text", nullable: true),
                    birthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    imprisonmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    freedomDate = table.Column<DateOnly>(type: "date", nullable: false),
                    addressId = table.Column<int>(type: "integer", nullable: false),
                    passportId = table.Column<int>(type: "integer", nullable: false),
                    photo = table.Column<BitArray>(type: "bit(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prisoner_pkey", x => x.id);
                    table.ForeignKey(
                        name: "Prisoner_addressId_fkey",
                        column: x => x.addressId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Prisoner_passportId_fkey",
                        column: x => x.passportId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "PassportData",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    employeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pkey", x => x.id);
                    table.ForeignKey(
                        name: "User_employeeId_fkey",
                        column: x => x.employeeId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ArticlePrisoner",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    prisonerId = table.Column<int>(type: "integer", nullable: false),
                    articleId = table.Column<int>(type: "integer", nullable: false),
                    statusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "ArticlePrisoner_articleId_fkey",
                        column: x => x.articleId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Article",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "ArticlePrisoner_prisonerId_fkey",
                        column: x => x.prisonerId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Prisoner",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "ArticlePrisoner_statusId_fkey",
                        column: x => x.statusId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "ArticleStatus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Jail_Prisoner",
                schema: "AnimeJailDb",
                columns: table => new
                {
                    jailId = table.Column<int>(type: "integer", nullable: false),
                    prisonerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    berthId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Jail_Prisoner_jailId_fkey",
                        column: x => x.jailId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Jail",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Jail_Prisoner_prisonerId_fkey",
                        column: x => x.prisonerId,
                        principalSchema: "AnimeJailDb",
                        principalTable: "Prisoner",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_cityId",
                schema: "AnimeJailDb",
                table: "Address",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePrisoner_articleId",
                schema: "AnimeJailDb",
                table: "ArticlePrisoner",
                column: "articleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePrisoner_prisonerId",
                schema: "AnimeJailDb",
                table: "ArticlePrisoner",
                column: "prisonerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePrisoner_statusId",
                schema: "AnimeJailDb",
                table: "ArticlePrisoner",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "City_name_key",
                schema: "AnimeJailDb",
                table: "City",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_countryId",
                schema: "AnimeJailDb",
                table: "City",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_regionId",
                schema: "AnimeJailDb",
                table: "City",
                column: "regionId");

            migrationBuilder.CreateIndex(
                name: "Country_name_key",
                schema: "AnimeJailDb",
                table: "Country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_passportId",
                schema: "AnimeJailDb",
                table: "Employee",
                column: "passportId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_workPositionId",
                schema: "AnimeJailDb",
                table: "Employee",
                column: "workPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Jail_typeId",
                schema: "AnimeJailDb",
                table: "Jail",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jail_Prisoner_jailId",
                schema: "AnimeJailDb",
                table: "Jail_Prisoner",
                column: "jailId");

            migrationBuilder.CreateIndex(
                name: "IX_Jail_Prisoner_prisonerId",
                schema: "AnimeJailDb",
                table: "Jail_Prisoner",
                column: "prisonerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportData_domiclleRegistrationAdressId",
                schema: "AnimeJailDb",
                table: "PassportData",
                column: "domiclleRegistrationAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportData_issuingCountryId",
                schema: "AnimeJailDb",
                table: "PassportData",
                column: "issuingCountryId");

            migrationBuilder.CreateIndex(
                name: "PassportData_serial_number_key",
                schema: "AnimeJailDb",
                table: "PassportData",
                column: "serial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prisoner_addressId",
                schema: "AnimeJailDb",
                table: "Prisoner",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisoner_passportId",
                schema: "AnimeJailDb",
                table: "Prisoner",
                column: "passportId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_countryId",
                schema: "AnimeJailDb",
                table: "Region",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "Region_name_key",
                schema: "AnimeJailDb",
                table: "Region",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_employeeId",
                schema: "AnimeJailDb",
                table: "User",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "User_login_key",
                schema: "AnimeJailDb",
                table: "User",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "WorkPostion_name_key",
                schema: "AnimeJailDb",
                table: "WorkPostion",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlePrisoner",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Jail_Prisoner",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "User",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "ArticleStatus",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Jail",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Prisoner",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "JailType",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "PassportData",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "WorkPostion",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "City",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "AnimeJailDb");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "AnimeJailDb");
        }
    }
}
