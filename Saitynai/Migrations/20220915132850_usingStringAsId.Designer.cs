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
    [Migration("20220915132850_usingStringAsId")]
    partial class usingStringAsId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Saitynai.Models.Playlist", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Url");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Saitynai.Models.Song", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Downloaded")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DownloadedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaylistUrl")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Url");

                    b.HasIndex("PlaylistUrl");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Saitynai.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Saitynai.Models.Playlist", b =>
                {
                    b.HasOne("Saitynai.Models.User", null)
                        .WithMany("Playlists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Saitynai.Models.Song", b =>
                {
                    b.HasOne("Saitynai.Models.Playlist", null)
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistUrl");
                });

            modelBuilder.Entity("Saitynai.Models.Playlist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Saitynai.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}