﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Q.Infrastructure.Context;

namespace Q.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Q.Domain.Assessment.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime?>("AssessmentDate");

                    b.Property<int?>("AssessmentScopeId");

                    b.Property<int?>("AssessmentStatusId");

                    b.Property<int?>("AssessmentTypeId");

                    b.Property<int?>("AssessorUserId");

                    b.Property<string>("DataId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSuperseded");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("PublishedBy");

                    b.Property<DateTime?>("PublishedDate");

                    b.Property<int?>("RecurrenceTypeId");

                    b.Property<string>("Reference");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentScopeId");

                    b.HasIndex("AssessmentStatusId");

                    b.HasIndex("AssessmentTypeId");

                    b.HasIndex("RecurrenceTypeId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("Q.Domain.Assessment.AssessmentScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AssessmentScopes");
                });

            modelBuilder.Entity("Q.Domain.Assessment.AssessmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AssessmentStatuses");
                });

            modelBuilder.Entity("Q.Domain.Assessment.AssessmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AssessmentTypes");
                });

            modelBuilder.Entity("Q.Domain.Asset.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("AssetTypeId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ManagingAgentId");

                    b.Property<int?>("ManagingAgentPortfolioId");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("PortfolioId");

                    b.Property<int?>("SubPortfolioId");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Q.Domain.Asset.AssetProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<int>("AssetId");

                    b.Property<string>("City");

                    b.Property<int?>("CountryId");

                    b.Property<int?>("CountyId");

                    b.Property<string>("DataId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("GrossInternalSize");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("KnownAs");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<decimal?>("NetInternalSize");

                    b.Property<short?>("NumberOfFloors");

                    b.Property<short?>("NumberOfPlantRooms");

                    b.Property<string>("Postcode");

                    b.Property<string>("PropertyReference");

                    b.Property<decimal?>("PropertySize");

                    b.Property<DateTime?>("StatusArchiveDate");

                    b.Property<DateTime?>("StatusStartDate");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("AssetProperties");
                });

            modelBuilder.Entity("Q.Domain.Asset.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");
                });

            modelBuilder.Entity("Q.Domain.Common.RecurrenceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("DatePart");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<short>("RecurrenceNumber");

                    b.HasKey("Id");

                    b.ToTable("RecurrenceTypes");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int?>("CustomEntityGroupId");

                    b.Property<int>("EntityGroupId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("TemplateName");

                    b.HasKey("Id");

                    b.HasIndex("CustomEntityGroupId");

                    b.ToTable("CustomEntityDefinitions");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomEntityGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CustomEntityGroups");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomEntityInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int?>("CustomEntityId");

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("InstanceId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("Status");

                    b.Property<int>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CustomEntityId");

                    b.ToTable("CustomEntityInstances");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int?>("CustomFieldTypeId");

                    b.Property<int>("CustomTabId");

                    b.Property<string>("DefaultValue");

                    b.Property<string>("FieldName");

                    b.Property<int>("FieldTypeId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool?>("IsMandatory");

                    b.Property<bool?>("IsVisible");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<short?>("SortOrder");

                    b.Property<string>("ToolTip");

                    b.HasKey("Id");

                    b.HasIndex("CustomFieldTypeId");

                    b.HasIndex("CustomTabId");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomFieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Caption");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("CustomFieldTypes");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomFieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("CustomEntityInstanceId");

                    b.Property<int>("CustomFieldId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CustomEntityInstanceId");

                    b.HasIndex("CustomFieldId");

                    b.ToTable("CustomFieldValues");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomTab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int?>("CustomEntityId");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsVisible");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<short?>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("CustomEntityId");

                    b.ToTable("CustomTabs");
                });

            modelBuilder.Entity("Q.Domain.Menu.MenuGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsVisible");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MenuGroups");
                });

            modelBuilder.Entity("Q.Domain.Menu.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Caption");

                    b.Property<string>("ClassName");

                    b.Property<bool>("HasChildren");

                    b.Property<string>("IconName");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsVisible");

                    b.Property<int>("MenuGroupId");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Route");

                    b.Property<int>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("MenuGroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Q.Domain.Task.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int?>("CompletedBy");

                    b.Property<string>("DataId")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("RecurrenceTypeId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TaskPriorityId");

                    b.Property<int>("TaskStatusId");

                    b.HasKey("Id");

                    b.HasIndex("RecurrenceTypeId");

                    b.HasIndex("TaskPriorityId");

                    b.HasIndex("TaskStatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Q.Domain.Task.TaskComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Comments");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskComments");
                });

            modelBuilder.Entity("Q.Domain.Task.TaskPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TaskPriorities");
                });

            modelBuilder.Entity("Q.Domain.Task.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool?>("IsActive");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("Q.Domain.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.Property<int>("UserRoleId");

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Q.Domain.User.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("DisplayName")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("PreferredLanguage");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("Q.Domain.User.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Q.Domain.User.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("Q.Domain.Assessment.Assessment", b =>
                {
                    b.HasOne("Q.Domain.Assessment.AssessmentScope", "AssessmentScope")
                        .WithMany("Assessments")
                        .HasForeignKey("AssessmentScopeId");

                    b.HasOne("Q.Domain.Assessment.AssessmentStatus")
                        .WithMany("Assessments")
                        .HasForeignKey("AssessmentStatusId");

                    b.HasOne("Q.Domain.Assessment.AssessmentType", "AssessmentType")
                        .WithMany("Assessments")
                        .HasForeignKey("AssessmentTypeId");

                    b.HasOne("Q.Domain.Common.RecurrenceType", "RecurrenceType")
                        .WithMany("Assessments")
                        .HasForeignKey("RecurrenceTypeId");
                });

            modelBuilder.Entity("Q.Domain.Asset.Asset", b =>
                {
                    b.HasOne("Q.Domain.Asset.AssetType", "AssetType")
                        .WithMany()
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.Asset.AssetProperty", b =>
                {
                    b.HasOne("Q.Domain.Asset.Asset", "Asset")
                        .WithMany("AssetProperties")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomEntity", b =>
                {
                    b.HasOne("Q.Domain.CustomEntity.CustomEntityGroup", "CustomEntityGroup")
                        .WithMany("CustomEntities")
                        .HasForeignKey("CustomEntityGroupId");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomEntityInstance", b =>
                {
                    b.HasOne("Q.Domain.CustomEntity.CustomEntity", "CustomEntity")
                        .WithMany()
                        .HasForeignKey("CustomEntityId");
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomField", b =>
                {
                    b.HasOne("Q.Domain.CustomEntity.CustomFieldType", "CustomFieldType")
                        .WithMany("CustomFields")
                        .HasForeignKey("CustomFieldTypeId");

                    b.HasOne("Q.Domain.CustomEntity.CustomTab", "CustomTab")
                        .WithMany("CustomFields")
                        .HasForeignKey("CustomTabId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomFieldValue", b =>
                {
                    b.HasOne("Q.Domain.CustomEntity.CustomEntityInstance", "CustomEntityInstance")
                        .WithMany("CustomFieldValues")
                        .HasForeignKey("CustomEntityInstanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Q.Domain.CustomEntity.CustomField", "CustomField")
                        .WithMany("CustomFieldValues")
                        .HasForeignKey("CustomFieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.CustomEntity.CustomTab", b =>
                {
                    b.HasOne("Q.Domain.CustomEntity.CustomEntity", "CustomEntity")
                        .WithMany()
                        .HasForeignKey("CustomEntityId");
                });

            modelBuilder.Entity("Q.Domain.Menu.MenuItem", b =>
                {
                    b.HasOne("Q.Domain.Menu.MenuGroup")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Q.Domain.Menu.MenuItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Q.Domain.Task.Task", b =>
                {
                    b.HasOne("Q.Domain.Common.RecurrenceType")
                        .WithMany("Tasks")
                        .HasForeignKey("RecurrenceTypeId");

                    b.HasOne("Q.Domain.Task.TaskPriority", "TaskPriority")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskPriorityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Q.Domain.Task.TaskStatus", "TaskStatus")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.Task.TaskComment", b =>
                {
                    b.HasOne("Q.Domain.Task.Task", "Task")
                        .WithMany("TaskComments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.User.User", b =>
                {
                    b.HasOne("Q.Domain.User.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Q.Domain.User.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Q.Domain.User.UserProfile", b =>
                {
                    b.HasOne("Q.Domain.User.User")
                        .WithOne("UserProfile")
                        .HasForeignKey("Q.Domain.User.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
