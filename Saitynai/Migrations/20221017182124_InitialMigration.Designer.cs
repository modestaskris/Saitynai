// <auto-generated />
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
    [Migration("20221017182124_InitialMigration")]
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
                            PasswordHash = new byte[] { 191, 158, 220, 67, 9, 59, 142, 151, 199, 220, 59, 147, 173, 73, 51, 62, 24, 18, 12, 122, 207, 128, 69, 52, 26, 24, 221, 46, 215, 80, 173, 1, 150, 110, 174, 36, 147, 111, 88, 217, 112, 42, 234, 110, 34, 122, 12, 92, 162, 74, 1, 12, 31, 179, 147, 164, 102, 115, 232, 177, 254, 225, 90, 132 },
                            PasswordSalt = new byte[] { 118, 57, 132, 229, 48, 139, 235, 83, 210, 109, 231, 247, 111, 145, 155, 177, 205, 74, 227, 23, 199, 227, 205, 147, 41, 68, 127, 248, 55, 114, 140, 251, 11, 164, 219, 84, 252, 196, 78, 36, 181, 72, 154, 91, 214, 119, 187, 224, 19, 128, 44, 183, 43, 194, 46, 120, 209, 216, 169, 216, 130, 240, 98, 214, 53, 181, 116, 14, 87, 149, 232, 115, 50, 19, 157, 94, 173, 134, 92, 168, 10, 11, 171, 246, 242, 102, 235, 128, 118, 251, 101, 18, 169, 71, 204, 181, 88, 226, 64, 63, 146, 9, 94, 165, 128, 222, 75, 187, 94, 78, 7, 166, 73, 161, 89, 114, 88, 201, 57, 155, 125, 4, 106, 90, 39, 117, 53, 211 },
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
