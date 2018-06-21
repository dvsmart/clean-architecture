﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Q.Infrastructure.Context;

namespace Q.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180621164349_ModifiedTaskTable")]
    partial class ModifiedTaskTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Q.Domain.Menu.MenuGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsVisible");

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

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Caption");

                    b.Property<string>("ClassName");

                    b.Property<bool>("HasChildren");

                    b.Property<string>("IconName");

                    b.Property<bool>("IsVisible");

                    b.Property<int>("MenuGroupId");

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

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("PriorityId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("StatusId");

                    b.Property<int?>("TaskPriorityId");

                    b.Property<int?>("TaskStatusId");

                    b.HasKey("Id");

                    b.HasIndex("TaskPriorityId");

                    b.HasIndex("TaskStatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Q.Domain.Task.TaskPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

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

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool?>("IsActive");

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

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.Property<int?>("UserRoleId");

                    b.Property<int?>("UserTypeId");

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

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("DisplayName");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

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

                    b.Property<DateTime>("AddedDate");

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

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
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
                    b.HasOne("Q.Domain.Task.TaskPriority")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskPriorityId");

                    b.HasOne("Q.Domain.Task.TaskStatus")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStatusId");
                });

            modelBuilder.Entity("Q.Domain.User.User", b =>
                {
                    b.HasOne("Q.Domain.User.UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId");

                    b.HasOne("Q.Domain.User.UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId");
                });

            modelBuilder.Entity("Q.Domain.User.UserProfile", b =>
                {
                    b.HasOne("Q.Domain.User.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("Q.Domain.User.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
