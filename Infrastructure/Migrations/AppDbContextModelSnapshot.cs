﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("registration");

                    b.Property<int>("RegistrationType")
                        .HasColumnType("integer")
                        .HasColumnName("registration_type");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("updated_by");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<bool>("Verified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("verified");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.HasIndex("Registration", "RoleId")
                        .IsUnique();

                    b.ToTable("accounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2099),
                            CreatedBy = 0,
                            Registration = "loiqdse140970@fpt.edu.vn",
                            RegistrationType = 0,
                            RoleId = 2,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2099),
                            UpdatedBy = 0,
                            UserId = 2,
                            Verified = true
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2108),
                            CreatedBy = 0,
                            Registration = "+84837226239",
                            RegistrationType = 1,
                            RoleId = 2,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2108),
                            UpdatedBy = 0,
                            UserId = 2,
                            Verified = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2115),
                            CreatedBy = 0,
                            Registration = "+848372262391",
                            RegistrationType = 1,
                            RoleId = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2115),
                            UpdatedBy = 0,
                            UserId = 1,
                            Verified = true
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2121),
                            CreatedBy = 0,
                            Registration = "loiqdse140970@fpt.edu.vn",
                            RegistrationType = 0,
                            RoleId = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2121),
                            UpdatedBy = 0,
                            UserId = 1,
                            Verified = false
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2127),
                            CreatedBy = 0,
                            Registration = "+84377322919",
                            RegistrationType = 1,
                            RoleId = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2128),
                            UpdatedBy = 0,
                            UserId = 3,
                            Verified = true
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2135),
                            CreatedBy = 0,
                            Registration = "trongdat2000@gmail.com",
                            RegistrationType = 0,
                            RoleId = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2136),
                            UpdatedBy = 0,
                            UserId = 3,
                            Verified = true
                        });
                });

            modelBuilder.Entity("Domain.Entities.AppFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Code")
                        .HasColumnType("uuid")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("files", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = new Guid("4d60e54a-6b06-43d2-9783-23550adace1d"),
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2034),
                            CreatedBy = 0,
                            Path = "abcabc",
                            Status = true,
                            Type = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2036),
                            UpdatedBy = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Description = "Role for driver",
                            Name = "DRIVER"
                        },
                        new
                        {
                            Id = 1,
                            Description = "Role for booker",
                            Name = "BOOKER"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Code")
                        .HasColumnType("uuid")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("FileId")
                        .HasColumnType("integer")
                        .HasColumnName("file_id");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = new Guid("f175a6be-109b-4551-b895-260af7406655"),
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2054),
                            CreatedBy = 0,
                            DateOfBirth = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2055),
                            FileId = 1,
                            Gender = 1,
                            Name = "Quach Dai Loi",
                            Status = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2054),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 2,
                            Code = new Guid("b44897e0-7068-4216-a538-34ff51734a51"),
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2064),
                            CreatedBy = 0,
                            DateOfBirth = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2080),
                            Gender = 1,
                            Name = "Olivier",
                            Status = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2065),
                            UpdatedBy = 0
                        },
                        new
                        {
                            Id = 3,
                            Code = new Guid("3d5f2e98-190a-4dbd-b347-09f8b856f57b"),
                            CreatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2089),
                            CreatedBy = 0,
                            DateOfBirth = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2090),
                            Gender = 1,
                            Name = "Dat Do",
                            Status = 1,
                            UpdatedAt = new DateTime(2022, 8, 18, 10, 25, 9, 1, DateTimeKind.Utc).AddTicks(2089),
                            UpdatedBy = 0
                        });
                });

            modelBuilder.Entity("Domain.Entities.VerifiedCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expired_time");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("registration");

                    b.Property<int>("RegistrationType")
                        .HasColumnType("integer")
                        .HasColumnName("registration_type");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("verified_codes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Account", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.AppFile", "File")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.User", "FileId");

                    b.Navigation("File");
                });

            modelBuilder.Entity("Domain.Entities.AppFile", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
