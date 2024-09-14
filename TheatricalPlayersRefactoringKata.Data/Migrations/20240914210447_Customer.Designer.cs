﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheatricalPlayersRefactoringKata.Data;

#nullable disable

namespace TheatricalPlayersRefactoringKata.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240914210447_Customer")]
    partial class Customer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.33");

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Performance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Audience")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlayId1")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("PlayId1");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Play", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Lines")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Invoice", b =>
                {
                    b.HasOne("TheatricalPlayersRefactoringKata.Data.Domain.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Performance", b =>
                {
                    b.HasOne("TheatricalPlayersRefactoringKata.Data.Domain.Invoice", null)
                        .WithMany("Performances")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("TheatricalPlayersRefactoringKata.Data.Domain.Play", "Play")
                        .WithMany()
                        .HasForeignKey("PlayId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Play");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("TheatricalPlayersRefactoringKata.Data.Domain.Invoice", b =>
                {
                    b.Navigation("Performances");
                });
#pragma warning restore 612, 618
        }
    }
}
