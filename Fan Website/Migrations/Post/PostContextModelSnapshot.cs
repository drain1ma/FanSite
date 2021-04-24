﻿// <auto-generated />
using System;
using Fan_Website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fan_Website.Migrations.Post
{
    [DbContext(typeof(PostContext))]
    partial class PostContextModelSnapshot : ModelSnapshot
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
                    b.Property<string>("ForumId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForumId");

                    b.ToTable("Forums");

                    b.HasData(
                        new
                        {
                            ForumId = "IX",
                            CreatedOn = new DateTime(2021, 4, 24, 18, 50, 33, 119, DateTimeKind.Local).AddTicks(2291),
                            Description = "A place to talk about Final Fantasy IX!",
                            PostTitle = "Final Fantasy IX",
                            UserName = "linguisticgamer98"
                        },
                        new
                        {
                            ForumId = "X",
                            CreatedOn = new DateTime(2021, 4, 24, 18, 50, 33, 121, DateTimeKind.Local).AddTicks(1525),
                            Description = "A place to talk about Final Fantasy X!",
                            PostTitle = "Final Fantasy X",
                            UserName = "mattdrain98"
                        });
                });

            modelBuilder.Entity("Fan_Website.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForumId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("ForumId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Content = "Like I said in the title, this is my favorite game and nothing can change my mind about that.",
                            CreatedOn = new DateTime(2021, 4, 24, 22, 50, 33, 118, DateTimeKind.Utc).AddTicks(541),
                            ForumId = "IX",
                            Title = "This is my favorite game!",
                            UserName = "linguisticgamer98"
                        });
                });

            modelBuilder.Entity("Fan_Website.Models.Post", b =>
                {
                    b.HasOne("Fan_Website.Models.Forum", "Forum")
                        .WithMany()
                        .HasForeignKey("ForumId");

                    b.Navigation("Forum");
                });
#pragma warning restore 612, 618
        }
    }
}
