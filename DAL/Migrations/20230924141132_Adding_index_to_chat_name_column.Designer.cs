﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(NetmailChatDatabaseContext))]
    [Migration("20230924141132_Adding_index_to_chat_name_column")]
    partial class Adding_index_to_chat_name_column
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.ChatMessage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatRoomID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ChatRoomID");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("DAL.Entities.ChatRoom", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("DAL.Entities.ChatMessage", b =>
                {
                    b.HasOne("DAL.Entities.ChatRoom", "ChatRoom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");
                });

            modelBuilder.Entity("DAL.Entities.ChatRoom", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
