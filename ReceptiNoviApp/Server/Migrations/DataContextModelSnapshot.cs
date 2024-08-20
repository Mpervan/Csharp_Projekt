﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReceptiNoviApp.Server.Data;

#nullable disable

namespace ReceptiNoviApp.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("ReceptiNoviApp.Shared.Kategorija", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("ReceptiNoviApp.Shared.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("ReceptiNoviApp.Shared.Recenzija", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Idkorisnik")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Idrecept")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Ocjena")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Recenzije");
                });

            modelBuilder.Entity("ReceptiNoviApp.Shared.Recept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idkategorije")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idkorisnik")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Img")
                        .HasColumnType("TEXT");

                    b.Property<long?>("KategorijaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KratkiOpis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Priprema")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sastojci")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vege")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Recepti");
                });

            modelBuilder.Entity("ReceptiNoviApp.Shared.Recept", b =>
                {
                    b.HasOne("ReceptiNoviApp.Shared.Kategorija", null)
                        .WithMany("Recepts")
                        .HasForeignKey("KategorijaId");
                });

            modelBuilder.Entity("ReceptiNoviApp.Shared.Kategorija", b =>
                {
                    b.Navigation("Recepts");
                });
#pragma warning restore 612, 618
        }
    }
}
