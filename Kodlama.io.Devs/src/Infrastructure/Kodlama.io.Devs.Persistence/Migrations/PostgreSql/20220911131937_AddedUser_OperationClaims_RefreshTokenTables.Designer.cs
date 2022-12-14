// <auto-generated />
using System;
using Kodlama.io.Devs.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations.PostgreSql
{
    [DbContext(typeof(EfPostgreDbContext))]
    [Migration("20220911131937_AddedUser_OperationClaims_RefreshTokenTables")]
    partial class AddedUser_OperationClaims_RefreshTokenTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OperationClaim");
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(2);

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("text");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("text")
                        .HasColumnOrder(7);

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(5);

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text")
                        .HasColumnOrder(6);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("integer")
                        .HasColumnOrder(7);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnOrder(5);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnOrder(4);

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Technology", (string)null);
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguageTechnology", b =>
                {
                    b.HasBaseType("Kodlama.io.Devs.Domain.Entities.Technology");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("ProgrammingLanguageTechnologies", (string)null);
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguageTechnology", b =>
                {
                    b.HasOne("Kodlama.io.Devs.Domain.Entities.Technology", null)
                        .WithOne()
                        .HasForeignKey("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguageTechnology", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("ProgrammingLanguageTechnologies")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("ProgrammingLanguageTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
