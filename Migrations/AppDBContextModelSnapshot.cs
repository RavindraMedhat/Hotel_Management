﻿// <auto-generated />
using System;
using Hotel_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel_Management.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel_Management.Models.HotelBranchTB", b =>
                {
                    b.Property<int>("Branch_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active_Flag")
                        .HasColumnType("bit");

                    b.Property<string>("Branch_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Branch_Contact_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch_Contect_Person")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Branch_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Branch_Email_Adderss")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Branch_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Branch_map_coordinate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Delete_Flag")
                        .HasColumnType("bit");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Hotel_ID")
                        .HasColumnType("int");

                    b.Property<float>("Priority")
                        .HasColumnType("real");

                    b.HasKey("Branch_ID");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelBranchTB");
                });

            modelBuilder.Entity("Hotel_Management.Models.HotelTB", b =>
                {
                    b.Property<int>("Hotel_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active_Flag")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Contact_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contect_Person")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Delete_Flag")
                        .HasColumnType("bit");

                    b.Property<string>("Email_Adderss")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Hotel_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Hotel_map_coordinate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Priority")
                        .HasColumnType("real");

                    b.Property<string>("Standard_check_In_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Standard_check_out_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hotel_ID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotel_Management.Models.HotelBranchTB", b =>
                {
                    b.HasOne("Hotel_Management.Models.HotelTB", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");
                });
#pragma warning restore 612, 618
        }
    }
}
