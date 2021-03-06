﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YunruiXie.HotelManagement.Infrastructure.Data;

namespace YunruiXie.HotelManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    [Migration("20201219034142_NewStart")]
    partial class NewStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.CUSTOMER", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ADDRESS")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("ADVANCE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BookingDays")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CHECKIN")
                        .HasColumnType("datetime2");

                    b.Property<string>("CNAME")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EMAIL")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PHONE")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ROOMNO")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPERSONS")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ROOMNO")
                        .IsUnique()
                        .HasFilter("[ROOMNO] IS NOT NULL");

                    b.ToTable("CUSTOMERS");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.ROOM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("RTCODE")
                        .HasColumnType("int");

                    b.Property<int?>("RoomtypeId")
                        .HasColumnType("int");

                    b.Property<bool?>("STATUS")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RoomtypeId");

                    b.ToTable("ROOMS");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.ROOMTYPE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RTDESC")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ROOMTYPES");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.SERVICE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("AMOUNT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ROOMNO")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("SDESC")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("SERVICES");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.CUSTOMER", b =>
                {
                    b.HasOne("YunruiXie.HotelManagement.Core.Entities.ROOM", "Room")
                        .WithOne("Customer")
                        .HasForeignKey("YunruiXie.HotelManagement.Core.Entities.CUSTOMER", "ROOMNO");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.ROOM", b =>
                {
                    b.HasOne("YunruiXie.HotelManagement.Core.Entities.ROOMTYPE", "Roomtype")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomtypeId");

                    b.Navigation("Roomtype");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.SERVICE", b =>
                {
                    b.HasOne("YunruiXie.HotelManagement.Core.Entities.ROOM", "Room")
                        .WithMany("Services")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.ROOM", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("YunruiXie.HotelManagement.Core.Entities.ROOMTYPE", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
