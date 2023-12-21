﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    partial class RealEstateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RealEstate.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.BasePost", b =>
                {
                    b.Property<Guid>("BasePostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OfferType")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("TitlePost")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BasePostId");

                    b.HasIndex("AddressId");

                    b.ToTable("BasePosts");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.CommercialCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CommercialCategories");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.CommercialSpecific", b =>
                {
                    b.Property<Guid>("CommercialSpecificId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CommercialCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SpecificName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CommercialSpecificId");

                    b.HasIndex("CommercialCategoryId");

                    b.ToTable("CommercialSpecifics");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.HouseType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HouseTypes");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.LotClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LotClassifications");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Partitioning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Partitionings");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Apartment", b =>
                {
                    b.HasBaseType("RealEstate.Domain.Entities.BasePost");

                    b.Property<int>("BuildYear")
                        .HasColumnType("integer");

                    b.Property<int>("Comfort")
                        .HasColumnType("integer");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<Guid>("PartitioningId")
                        .HasColumnType("uuid");

                    b.Property<int>("RoomCount")
                        .HasColumnType("integer");

                    b.Property<double>("UsefulSurface")
                        .HasColumnType("double precision");

                    b.HasIndex("PartitioningId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Commercial", b =>
                {
                    b.HasBaseType("RealEstate.Domain.Entities.BasePost");

                    b.Property<Guid>("CommercialSpecificId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Disponibility")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("UsefulSurface")
                        .HasColumnType("double precision");

                    b.HasIndex("CommercialSpecificId");

                    b.ToTable("Commercials");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.HotelPension", b =>
                {
                    b.HasBaseType("RealEstate.Domain.Entities.BasePost");

                    b.Property<int>("RoomCount")
                        .HasColumnType("integer");

                    b.Property<double>("RoomSurface")
                        .HasColumnType("double precision");

                    b.Property<double>("UsefulSurface")
                        .HasColumnType("double precision");

                    b.ToTable("HotelPensions");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.House", b =>
                {
                    b.HasBaseType("RealEstate.Domain.Entities.BasePost");

                    b.Property<int>("BuildYear")
                        .HasColumnType("integer");

                    b.Property<int>("Comfort")
                        .HasColumnType("integer");

                    b.Property<int>("FloorCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("HouseTypeId")
                        .HasColumnType("uuid");

                    b.Property<double>("LotArea")
                        .HasColumnType("double precision");

                    b.Property<int>("RoomCount")
                        .HasColumnType("integer");

                    b.Property<double>("UsefulSurface")
                        .HasColumnType("double precision");

                    b.HasIndex("HouseTypeId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Lot", b =>
                {
                    b.HasBaseType("RealEstate.Domain.Entities.BasePost");

                    b.Property<double>("LotArea")
                        .HasColumnType("double precision");

                    b.Property<Guid>("LotClassificationId")
                        .HasColumnType("uuid");

                    b.Property<double>("StreetFrontage")
                        .HasColumnType("double precision");

                    b.HasIndex("LotClassificationId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.BasePost", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.CommercialSpecific", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.CommercialCategory", "CommercialCategory")
                        .WithMany()
                        .HasForeignKey("CommercialCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommercialCategory");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Apartment", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.BasePost", null)
                        .WithOne()
                        .HasForeignKey("RealEstate.Domain.Entities.Apartment", "BasePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.Partitioning", "Partitioning")
                        .WithMany()
                        .HasForeignKey("PartitioningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partitioning");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Commercial", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.BasePost", null)
                        .WithOne()
                        .HasForeignKey("RealEstate.Domain.Entities.Commercial", "BasePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.CommercialSpecific", "CommercialSpecific")
                        .WithMany()
                        .HasForeignKey("CommercialSpecificId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommercialSpecific");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.HotelPension", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.BasePost", null)
                        .WithOne()
                        .HasForeignKey("RealEstate.Domain.Entities.HotelPension", "BasePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.House", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.BasePost", null)
                        .WithOne()
                        .HasForeignKey("RealEstate.Domain.Entities.House", "BasePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.HouseType", "HouseType")
                        .WithMany()
                        .HasForeignKey("HouseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseType");
                });

            modelBuilder.Entity("RealEstate.Domain.Entities.Lot", b =>
                {
                    b.HasOne("RealEstate.Domain.Entities.BasePost", null)
                        .WithOne()
                        .HasForeignKey("RealEstate.Domain.Entities.Lot", "BasePostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Entities.LotClassification", "LotClassification")
                        .WithMany()
                        .HasForeignKey("LotClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LotClassification");
                });
#pragma warning restore 612, 618
        }
    }
}
