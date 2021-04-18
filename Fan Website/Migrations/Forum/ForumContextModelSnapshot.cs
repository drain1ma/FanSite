﻿// <auto-generated />
using System;
using Fan_Website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fan_Website.Migrations.Forum
{
    [DbContext(typeof(ForumContext))]
    partial class ForumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fan_Website.Models.Forum", b =>
                {
                    b.Property<int>("ForumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Post")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForumId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            ForumId = 1,
                            CreatedOn = new DateTime(2021, 4, 18, 0, 15, 49, 427, DateTimeKind.Local).AddTicks(6027),
                            Post = "The reason I believe this to be the best game is due to the character development as well as the pacing of the story as a whole. Without the characters the game would not have been nearly as good, although the story was still fantastic as well.",
                            PostTitle = "Final Fantasy IX is the best",
                            UserName = "mattdrain98"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
