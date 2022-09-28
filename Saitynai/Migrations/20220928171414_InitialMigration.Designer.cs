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
    [Migration("20220928171414_InitialMigration")]
    partial class InitialMigration
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

                    b.Property<DateTime>("DownloadedDate")
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
                            PasswordHash = new byte[] { 67, 140, 127, 191, 243, 207, 215, 3, 161, 148, 117, 205, 220, 30, 252, 174, 151, 68, 163, 44, 1, 28, 49, 239, 204, 7, 96, 114, 100, 183, 111, 54, 82, 248, 208, 255, 198, 221, 71, 150, 101, 168, 67, 233, 34, 141, 73, 169, 253, 90, 56, 155, 122, 16, 33, 97, 247, 44, 81, 16, 122, 66, 58, 174 },
                            PasswordSalt = new byte[] { 36, 92, 66, 19, 164, 17, 31, 157, 86, 102, 34, 36, 103, 253, 174, 200, 135, 60, 61, 128, 29, 152, 109, 241, 124, 25, 129, 92, 147, 151, 80, 183, 205, 16, 183, 21, 195, 168, 93, 241, 174, 111, 121, 170, 235, 38, 210, 46, 42, 212, 144, 170, 192, 187, 176, 167, 80, 107, 26, 65, 15, 69, 85, 70, 197, 135, 103, 76, 91, 14, 155, 245, 220, 102, 111, 94, 99, 159, 75, 202, 136, 69, 172, 145, 178, 196, 197, 193, 126, 148, 61, 250, 196, 168, 104, 156, 166, 141, 61, 37, 229, 97, 165, 159, 226, 78, 53, 19, 185, 189, 242, 117, 106, 167, 160, 151, 49, 61, 200, 17, 245, 130, 121, 191, 36, 78, 5, 117 },
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