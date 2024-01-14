﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Waifu.Data;

#nullable disable

namespace Waifu.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240114122603_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Waifu.Models.ChatChannel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("channels");
                });

            modelBuilder.Entity("Waifu.Models.ChatMessage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Sender")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TargetChannelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("Waifu.Models.RoleplayCharacter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePictureHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SampleMessages")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("Waifu.Models.ChatChannel", b =>
                {
                    b.HasOne("Waifu.Models.RoleplayCharacter", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
