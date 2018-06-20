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

            modelBuilder.Entity("Q.Domain.Menu.MenuGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsVisible");

                    b.Property<DateTime>("ModifiedDate");

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

                    b.Property<DateTime>("ModifiedDate");

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

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
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
#pragma warning restore 612, 618
        }
    }
}
