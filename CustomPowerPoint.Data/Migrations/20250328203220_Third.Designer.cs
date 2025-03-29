﻿// <auto-generated />
using System;
using CustomPowerPoint.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomPowerPoint.Data.Migrations
{
    [DbContext(typeof(WebDbContext))]
    [Migration("20250328203220_Third")]
    partial class Third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomPowerPoint.Data.Models.PresentationData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorNickname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("CustomPowerPoint.Data.Models.SlideData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int[]>("Elements")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid?>("PresentationDataId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PresentationDataId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("CustomPowerPoint.Data.Models.SlideElementData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("PositionX")
                        .HasColumnType("real");

                    b.Property<float>("PositionY")
                        .HasColumnType("real");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("SlideElements");
                });

            modelBuilder.Entity("CustomPowerPoint.Data.Models.UserPresentationRoleData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserPresentationRoles");
                });

            modelBuilder.Entity("PresentationDataUserPresentationRoleData", b =>
                {
                    b.Property<Guid>("PresentationDataId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("PresentationDataId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PresentationUsers", (string)null);
                });

            modelBuilder.Entity("CustomPowerPoint.Data.Models.SlideData", b =>
                {
                    b.HasOne("CustomPowerPoint.Data.Models.PresentationData", null)
                        .WithMany("Slides")
                        .HasForeignKey("PresentationDataId");
                });

            modelBuilder.Entity("PresentationDataUserPresentationRoleData", b =>
                {
                    b.HasOne("CustomPowerPoint.Data.Models.PresentationData", null)
                        .WithMany()
                        .HasForeignKey("PresentationDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomPowerPoint.Data.Models.UserPresentationRoleData", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomPowerPoint.Data.Models.PresentationData", b =>
                {
                    b.Navigation("Slides");
                });
#pragma warning restore 612, 618
        }
    }
}
