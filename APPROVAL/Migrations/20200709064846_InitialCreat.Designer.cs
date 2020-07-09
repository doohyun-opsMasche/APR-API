﻿// <auto-generated />
using System;
using APPROVAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APPROVAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200709064846_InitialCreat")]
    partial class InitialCreat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("APPROVAL.Models.Form", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FORM_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("approvalLineModifyFlag")
                        .IsRequired()
                        .HasColumnName("FORM_APPROVAL_LINE_MODIFY_FLAG")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<int?>("categoryId")
                        .IsRequired()
                        .HasColumnName("FORM_CATEGORY_ID")
                        .HasColumnType("int");

                    b.Property<int>("delayDay")
                        .HasColumnName("FORM_DELAY_ALERT_DAY")
                        .HasColumnType("int");

                    b.Property<string>("delayTime")
                        .IsRequired()
                        .HasColumnName("FORM_DELAY_ALERT_TIME")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("delegatePolicyId")
                        .HasColumnName("FORM_DELEGATE_POLICY_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departmentBoxReadFlag")
                        .IsRequired()
                        .HasColumnName("FORM_DEPARTMENT_BOX_READ_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("description")
                        .HasColumnName("FORM_DESCRIPTION")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("directionFlag")
                        .IsRequired()
                        .HasColumnName("FORM_DIRECTION_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("displayFlag")
                        .IsRequired()
                        .HasColumnName("DISPLAY_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("documentNumberFlag")
                        .IsRequired()
                        .HasColumnName("FORM_DOCUMENT_NUMBER_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("documentTransferFlag")
                        .IsRequired()
                        .HasColumnName("FORM_DOCUMENT_TRANSFER_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<int>("fileGroupId")
                        .HasColumnName("FORM_FILE_GROUP_ID")
                        .HasColumnType("int");

                    b.Property<string>("legacyFlag")
                        .IsRequired()
                        .HasColumnName("FORM_LEGACY_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("legacyType")
                        .HasColumnName("FORM_LEGACY_TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("legacyUrl")
                        .HasColumnName("FORM_LEGACY_URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mandatoryFlag")
                        .IsRequired()
                        .HasColumnName("FORM_MANDATORY_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("FORM_NM")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("sort")
                        .IsRequired()
                        .HasColumnName("FORM_SORT")
                        .HasColumnType("int");

                    b.Property<string>("useFlag")
                        .IsRequired()
                        .HasColumnName("USE_FLAG")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.HasIndex("fileGroupId");

                    b.ToTable("TB_FORM");
                });

            modelBuilder.Entity("APPROVAL.Models.FormCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FORM_CATEGORY_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("insertDate")
                        .IsRequired()
                        .HasColumnName("INS_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("languageFlag")
                        .IsRequired()
                        .HasColumnName("FORM_CATEGORY_LANGUAGE_FLAG")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("FORM_CATEGORY_NM")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("sort")
                        .IsRequired()
                        .HasColumnName("FORM_CATEGORY_SORT")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("TB_FORM_CATEGORY");
                });

            modelBuilder.Entity("APPROVAL.Models.FormDisplayAuth", b =>
                {
                    b.Property<int?>("authId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FORM_DISPLAY_AUTH_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("formId")
                        .HasColumnName("FORM_DISPLAY_AUTH_FORM_ID")
                        .HasColumnType("int");

                    b.Property<int?>("FormFileid")
                        .HasColumnType("int");

                    b.Property<string>("authResource")
                        .IsRequired()
                        .HasColumnName("FORM_DISPLAY_AUTH_RESOURCE")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("authType")
                        .IsRequired()
                        .HasColumnName("FORM_DISPLAY_AUTH_TYPE")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("authId", "formId");

                    b.HasIndex("FormFileid");

                    b.HasIndex("formId");

                    b.ToTable("TB_FORM_DISPLAY_AUTH");
                });

            modelBuilder.Entity("APPROVAL.Models.FormFile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FORM_FILE_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("folderFlag")
                        .IsRequired()
                        .HasColumnName("FORM_FILE_FOLDER_FLAG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupId")
                        .HasColumnName("FORM_FILE_GROUP_ID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("insertDate")
                        .IsRequired()
                        .HasColumnName("INS_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnName("FORM_FILE_PATH")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnName("FORM_FILE_TYPE")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.HasKey("id");

                    b.HasIndex("groupId");

                    b.ToTable("TB_FORM_FILE");
                });

            modelBuilder.Entity("APPROVAL.Models.FormFileGroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FORM_FILE_GROUP_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("displayName")
                        .IsRequired()
                        .HasColumnName("FORM_FILE_GROUP_DISPLAY_NM")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("insertDate")
                        .IsRequired()
                        .HasColumnName("INS_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("FORM_FILE_GROUP_NM")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("version")
                        .HasColumnName("FORM_FILE_GROUP_VERSION")
                        .HasColumnType("int")
                        .HasMaxLength(300);

                    b.HasKey("id");

                    b.ToTable("TB_FORM_FILE_GROUP");
                });

            modelBuilder.Entity("APPROVAL.Models.Form", b =>
                {
                    b.HasOne("APPROVAL.Models.FormCategory", "formCategory")
                        .WithMany("forms")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APPROVAL.Models.FormFileGroup", "formFileGroup")
                        .WithMany("forms")
                        .HasForeignKey("fileGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APPROVAL.Models.FormDisplayAuth", b =>
                {
                    b.HasOne("APPROVAL.Models.FormFile", null)
                        .WithMany("formDisplayAuths")
                        .HasForeignKey("FormFileid");

                    b.HasOne("APPROVAL.Models.Form", "form")
                        .WithMany("formDisplayAuths")
                        .HasForeignKey("formId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APPROVAL.Models.FormFile", b =>
                {
                    b.HasOne("APPROVAL.Models.FormFileGroup", "formFileGroup")
                        .WithMany("formFiles")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
