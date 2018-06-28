using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Q.Infrastructure.Migrations
{
    public partial class addedMoreTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomEntityGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEntityGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PublishedBy = table.Column<int>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: true),
                    AssessmentTypeId = table.Column<int>(nullable: false),
                    AssessmentScopeId = table.Column<int>(nullable: true),
                    AssessmentStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentScopes_AssessmentScopeId",
                        column: x => x.AssessmentScopeId,
                        principalTable: "AssessmentScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentStatuses_AssessmentStatusId",
                        column: x => x.AssessmentStatusId,
                        principalTable: "AssessmentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentTypes_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalTable: "AssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    PortfolioId = table.Column<int>(nullable: true),
                    SubPortfolioId = table.Column<int>(nullable: true),
                    ManagingAgentId = table.Column<int>(nullable: true),
                    ManagingAgentPortfolioId = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomEntityDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    TemplateName = table.Column<string>(nullable: true),
                    EntityGroupId = table.Column<int>(nullable: false),
                    CustomEntityGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEntityDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomEntityDefinitions_CustomEntityGroups_CustomEntityGroupId",
                        column: x => x.CustomEntityGroupId,
                        principalTable: "CustomEntityGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    AssetId = table.Column<int>(nullable: false),
                    PropertyReference = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountyId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    KnownAs = table.Column<string>(nullable: true),
                    PropertySize = table.Column<decimal>(nullable: true),
                    NetInternalSize = table.Column<decimal>(nullable: true),
                    GrossInternalSize = table.Column<decimal>(nullable: true),
                    NumberOfFloors = table.Column<short>(nullable: true),
                    NumberOfPlantRooms = table.Column<short>(nullable: true),
                    StatusStartDate = table.Column<DateTime>(nullable: true),
                    StatusArchiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetProperties_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomEntityInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    InstanceId = table.Column<string>(nullable: true),
                    TemplateId = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CustomEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEntityInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomEntityInstances_CustomEntityDefinitions_CustomEntityId",
                        column: x => x.CustomEntityId,
                        principalTable: "CustomEntityDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomTabs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    SortOrder = table.Column<short>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomTabs_CustomEntityDefinitions_CustomEntityId",
                        column: x => x.CustomEntityId,
                        principalTable: "CustomEntityDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    FieldTypeId = table.Column<int>(nullable: false),
                    CustomTabId = table.Column<int>(nullable: false),
                    IsMandatory = table.Column<bool>(nullable: true),
                    ToolTip = table.Column<string>(nullable: true),
                    DefaultValue = table.Column<string>(nullable: true),
                    SortOrder = table.Column<short>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: true),
                    CustomFieldTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFields_CustomFieldTypes_CustomFieldTypeId",
                        column: x => x.CustomFieldTypeId,
                        principalTable: "CustomFieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomFields_CustomTabs_CustomTabId",
                        column: x => x.CustomTabId,
                        principalTable: "CustomTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    CustomFieldId = table.Column<int>(nullable: false),
                    CustomEntityInstanceId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldValues_CustomEntityInstances_CustomEntityInstanceId",
                        column: x => x.CustomEntityInstanceId,
                        principalTable: "CustomEntityInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomFieldValues_CustomFields_CustomFieldId",
                        column: x => x.CustomFieldId,
                        principalTable: "CustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentScopeId",
                table: "Assessments",
                column: "AssessmentScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentStatusId",
                table: "Assessments",
                column: "AssessmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentTypeId",
                table: "Assessments",
                column: "AssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetProperties_AssetId",
                table: "AssetProperties",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomEntityDefinitions_CustomEntityGroupId",
                table: "CustomEntityDefinitions",
                column: "CustomEntityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomEntityInstances_CustomEntityId",
                table: "CustomEntityInstances",
                column: "CustomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomFieldTypeId",
                table: "CustomFields",
                column: "CustomFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomTabId",
                table: "CustomFields",
                column: "CustomTabId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_CustomEntityInstanceId",
                table: "CustomFieldValues",
                column: "CustomEntityInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_CustomFieldId",
                table: "CustomFieldValues",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTabs_CustomEntityId",
                table: "CustomTabs",
                column: "CustomEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "AssetProperties");

            migrationBuilder.DropTable(
                name: "CustomFieldValues");

            migrationBuilder.DropTable(
                name: "AssessmentScopes");

            migrationBuilder.DropTable(
                name: "AssessmentStatuses");

            migrationBuilder.DropTable(
                name: "AssessmentTypes");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "CustomEntityInstances");

            migrationBuilder.DropTable(
                name: "CustomFields");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "CustomFieldTypes");

            migrationBuilder.DropTable(
                name: "CustomTabs");

            migrationBuilder.DropTable(
                name: "CustomEntityDefinitions");

            migrationBuilder.DropTable(
                name: "CustomEntityGroups");
        }
    }
}
