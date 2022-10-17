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
    [Migration("20221016210853_mssql.azure_migration_510")]
    partial class mssqlazure_migration_510
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
                            PasswordHash = new byte[] { 169, 206, 90, 49, 179, 254, 160, 115, 86, 219, 79, 86, 182, 129, 239, 56, 91, 44, 87, 102, 182, 0, 60, 209, 60, 3, 50, 45, 18, 112, 81, 171, 37, 57, 13, 238, 168, 40, 183, 242, 93, 29, 104, 165, 96, 204, 131, 22, 116, 241, 169, 223, 162, 193, 150, 220, 3, 195, 216, 16, 81, 163, 48, 155 },
                            PasswordSalt = new byte[] { 71, 170, 1, 220, 208, 0, 26, 38, 238, 239, 52, 91, 51, 150, 140, 249, 21, 153, 171, 97, 204, 175, 161, 30, 139, 78, 147, 84, 222, 217, 31, 48, 55, 25, 210, 127, 66, 119, 26, 65, 93, 110, 96, 63, 187, 3, 39, 158, 89, 20, 75, 90, 84, 139, 10, 81, 205, 198, 175, 14, 170, 82, 160, 164, 164, 15, 253, 14, 230, 232, 126, 66, 126, 135, 177, 122, 164, 86, 119, 9, 46, 108, 13, 196, 7, 198, 82, 198, 153, 116, 243, 117, 186, 106, 112, 161, 78, 232, 158, 181, 136, 77, 82, 4, 241, 162, 198, 189, 196, 59, 185, 76, 51, 164, 11, 21, 90, 119, 113, 120, 173, 128, 36, 67, 5, 184, 210, 158 },
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