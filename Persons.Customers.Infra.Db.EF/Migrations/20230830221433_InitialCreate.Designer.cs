﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persons.Customers.Infra.Db.EF.Contexts;

#nullable disable

namespace Persons.Customers.Infra.Db.EF.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20230830221433_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Persons.Customers.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.ToTable("CustomerAddresses", (string)null);
                });

            modelBuilder.Entity("Persons.Customers.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("_statusId");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Persons.Customers.Domain.Entities.CustomerDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("_customerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerId");

                    b.Property<int>("_documentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("DocumentTypeId");

                    b.HasKey("Id");

                    b.HasIndex("_customerId")
                        .IsUnique();

                    b.HasIndex("_documentTypeId");

                    b.ToTable("CustomerDocuments", (string)null);
                });

            modelBuilder.Entity("Persons.Customers.Domain.Enums.CustomerStatusTypeEnum", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("CustomerStatusesType", (string)null);
                });

            modelBuilder.Entity("Persons.Customers.Domain.Enums.DocumentTypeEnum", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("DocumentType", (string)null);
                });

            modelBuilder.Entity("Persons.Customers.Domain.Entities.Address", b =>
                {
                    b.HasOne("Persons.Customers.Domain.Entities.Customer", null)
                        .WithOne("Address")
                        .HasForeignKey("Persons.Customers.Domain.Entities.Address", "CustomerId");
                });

            modelBuilder.Entity("Persons.Customers.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Persons.Customers.Domain.Enums.CustomerStatusTypeEnum", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Persons.Customers.Domain.Entities.CustomerDocument", b =>
                {
                    b.HasOne("Persons.Customers.Domain.Entities.Customer", "Customer")
                        .WithOne("Document")
                        .HasForeignKey("Persons.Customers.Domain.Entities.CustomerDocument", "_customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persons.Customers.Domain.Enums.DocumentTypeEnum", "DocumentType")
                        .WithMany()
                        .HasForeignKey("_documentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("Persons.Customers.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Document")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}