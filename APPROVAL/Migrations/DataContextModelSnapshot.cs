﻿// <auto-generated />
using System;
using APPROVAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APPROVAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APPROVAL.Models.Approver", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordhash")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("APPROVAL.Models.Command", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("howTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("platForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("APPROVAL.Models.Document", b =>
                {
                    b.Property<int>("processId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("companyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creatorDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creatorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("formId")
                        .HasColumnType("int");

                    b.Property<int>("ruleId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("processId");

                    b.ToTable("Document");
                });
#pragma warning restore 612, 618
        }
    }
}
