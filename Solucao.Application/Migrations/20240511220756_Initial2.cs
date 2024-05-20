using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solucao.Application.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    key = table.Column<string>(type: "varchar(50)", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Plate = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(15)", maxLength: 10, nullable: false),
                    PersonType = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Single = table.Column<bool>(type: "bit", nullable: false),
                    HasConsumable = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalAttributes",
                columns: table => new
                {
                    key = table.Column<string>(type: "varchar(50)", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentConsumables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ConsumableId = table.Column<Guid>(nullable: false),
                    EquipamentId = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentConsumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentConsumables_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipamentConsumables_Equipaments_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    modelFileName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    equipamentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Equipaments_equipamentId",
                        column: x => x.equipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipamentSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentId = table.Column<Guid>(nullable: false),
                    SpecificationId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentSpecifications_Equipaments_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TableName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RecordId = table.Column<Guid>(nullable: false),
                    Operation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Message = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StickyNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(type: "varchar(200)", nullable: false),
                    Resolved = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StickyNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StickyNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    fileAttribute = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    technicalAttribute = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    AttributeType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    modelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelAttributes_Models_modelId",
                        column: x => x.modelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 50, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(15)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(50)", maxLength: 30, nullable: true),
                    Complement = table.Column<string>(type: "varchar(50)", maxLength: 30, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    IsPhysicalPerson = table.Column<bool>(type: "bit", nullable: false),
                    IsAnnualContract = table.Column<bool>(type: "bit", nullable: true),
                    IsReceipt = table.Column<int>(type: "int", nullable: true),
                    NameForReceipt = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    HasAirConditioning = table.Column<bool>(type: "bit", nullable: true),
                    Has220V = table.Column<bool>(type: "bit", nullable: true),
                    HasStairs = table.Column<bool>(type: "bit", nullable: true),
                    TakeTransformer = table.Column<bool>(type: "bit", nullable: true),
                    HasTechnique = table.Column<bool>(type: "bit", nullable: true),
                    TechniqueOption1 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    TechniqueOption2 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    LandMark = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Responsible = table.Column<string>(type: "varchar(100)", maxLength: 70, nullable: true),
                    Specialty = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ClinicName = table.Column<string>(type: "varchar(200)", maxLength: 50, nullable: true),
                    ClinicCellPhone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true),
                    Secretary = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true),
                    Rg = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Ie = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EquipamentValues = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    EquipamentId = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(type: "varchar(100)", nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    NoCadastre = table.Column<bool>(type: "bit", nullable: false),
                    TemporaryName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DriverId = table.Column<Guid>(nullable: true),
                    DriverCollectsId = table.Column<Guid>(nullable: true),
                    TechniqueId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    TravelOn = table.Column<int>(type: "int", nullable: false),
                    ContractMade = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalTime = table.Column<int>(nullable: false),
                    ContractPath = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calendars_People_DriverCollectsId",
                        column: x => x.DriverCollectsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendars_People_DriverId",
                        column: x => x.DriverId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendars_Equipaments_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calendars_People_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEquipamentConsumables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<int>(nullable: false, defaultValue: 0),
                    CalendarId = table.Column<Guid>(nullable: false),
                    ConsumableId = table.Column<Guid>(nullable: false),
                    EquipamentId = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEquipamentConsumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEquipamentConsumables_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarEquipamentConsumables_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarEquipamentConsumables_Equipaments_EquipamentId",
                        column: x => x.EquipamentId,
                        principalTable: "Equipaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalendarSpecificationConsumables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CalendarId = table.Column<Guid>(nullable: false),
                    SpecificationId = table.Column<Guid>(nullable: false),
                    Initial = table.Column<int>(nullable: false, defaultValue: 0),
                    Final = table.Column<int>(nullable: false, defaultValue: 0),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarSpecificationConsumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarSpecificationConsumables_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarSpecificationConsumables_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalendarSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<Guid>(nullable: false),
                    SpecificationId = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarSpecifications_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarSpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEquipamentConsumables_CalendarId",
                table: "CalendarEquipamentConsumables",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEquipamentConsumables_ConsumableId",
                table: "CalendarEquipamentConsumables",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEquipamentConsumables_EquipamentId",
                table: "CalendarEquipamentConsumables",
                column: "EquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_ClientId",
                table: "Calendars",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DriverCollectsId",
                table: "Calendars",
                column: "DriverCollectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DriverId",
                table: "Calendars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_EquipamentId",
                table: "Calendars",
                column: "EquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TechniqueId",
                table: "Calendars",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSpecificationConsumables_CalendarId",
                table: "CalendarSpecificationConsumables",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSpecificationConsumables_SpecificationId",
                table: "CalendarSpecificationConsumables",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSpecifications_CalendarId",
                table: "CalendarSpecifications",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSpecifications_SpecificationId",
                table: "CalendarSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityId",
                table: "Clients",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StateId",
                table: "Clients",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentConsumables_ConsumableId",
                table: "EquipamentConsumables",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentConsumables_EquipamentId",
                table: "EquipamentConsumables",
                column: "EquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentSpecifications_EquipamentId",
                table: "EquipamentSpecifications",
                column: "EquipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentSpecifications_SpecificationId",
                table: "EquipamentSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelAttributes_modelId",
                table: "ModelAttributes",
                column: "modelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_equipamentId",
                table: "Models",
                column: "equipamentId");

            migrationBuilder.CreateIndex(
                name: "IX_StickyNotes_UserId",
                table: "StickyNotes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "CalendarEquipamentConsumables");

            migrationBuilder.DropTable(
                name: "CalendarSpecificationConsumables");

            migrationBuilder.DropTable(
                name: "CalendarSpecifications");

            migrationBuilder.DropTable(
                name: "EquipamentConsumables");

            migrationBuilder.DropTable(
                name: "EquipamentSpecifications");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "ModelAttributes");

            migrationBuilder.DropTable(
                name: "StickyNotes");

            migrationBuilder.DropTable(
                name: "TechnicalAttributes");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Equipaments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
