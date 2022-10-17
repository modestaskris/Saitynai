﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saitynai.Helpers;

#nullable disable

namespace Saitynai.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221017093155_mssql.azure_migration_966")]
    partial class mssqlazure_migration_966
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Saitynai.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId");

                    b.HasIndex("Username");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Saitynai.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"), 1L, 1);

                    b.Property<int>("CategorieCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaylistId");

                    b.HasIndex("CategorieCategoryId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Saitynai.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"), 1L, 1);

                    b.Property<bool>("Downloaded")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DownloadedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Saitynai.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Username = "admin",
                            PasswordHash = new byte[] { 111, 9, 70, 174, 216, 54, 63, 151, 9, 78, 106, 136, 84, 119, 39, 103, 119, 141, 158, 32, 40, 88, 220, 17, 203, 141, 81, 231, 197, 179, 81, 213, 45, 30, 88, 181, 187, 56, 231, 74, 25, 104, 101, 247, 60, 198, 237, 115, 84, 28, 17, 83, 240, 161, 250, 189, 139, 243, 207, 12, 56, 189, 142, 120 },
                            PasswordSalt = new byte[] { 152, 91, 24, 173, 68, 87, 113, 184, 95, 195, 227, 25, 95, 30, 106, 144, 209, 43, 214, 93, 9, 121, 82, 39, 167, 147, 3, 185, 6, 100, 231, 174, 101, 178, 72, 143, 7, 161, 99, 228, 185, 228, 150, 204, 248, 224, 32, 37, 166, 71, 141, 247, 20, 40, 83, 85, 180, 16, 119, 228, 89, 42, 34, 194, 62, 144, 93, 225, 180, 76, 89, 84, 88, 245, 210, 55, 63, 55, 202, 66, 134, 22, 168, 192, 160, 142, 247, 48, 249, 56, 166, 161, 143, 62, 42, 15, 67, 78, 44, 195, 195, 230, 148, 185, 203, 9, 68, 58, 36, 149, 183, 159, 26, 203, 130, 188, 209, 9, 246, 255, 110, 233, 75, 67, 173, 142, 137, 153 },
                            Role = 0,
                            UserId = -1
                        });
                });

            modelBuilder.Entity("Saitynai.Models.Category", b =>
                {
                    b.HasOne("Saitynai.Models.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Saitynai.Models.Playlist", b =>
                {
                    b.HasOne("Saitynai.Models.Category", "Categorie")
                        .WithMany("Playlists")
                        .HasForeignKey("CategorieCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("Saitynai.Models.Song", b =>
                {
                    b.HasOne("Saitynai.Models.Playlist", "Playlist")
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("Saitynai.Models.Category", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("Saitynai.Models.Playlist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Saitynai.Models.User", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}