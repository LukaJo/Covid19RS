﻿// <auto-generated />
using Covid19RS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19RS.Migrations
{
    [DbContext(typeof(Covid19RSContext))]
    partial class Covid19RSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Covid19RS.Models.Covid19", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojAktivnihSlucajeva");

                    b.Property<int>("BrojOsobaNaRespiratorima");

                    b.Property<int>("BrojPotvrdjenihSlucajeva24h");

                    b.Property<int>("BrojPreminulihosoba24h");

                    b.Property<int>("BrojSmrtnihSlucajeva");

                    b.Property<int>("BrojTestiranihOsoba");

                    b.Property<int>("BrojTestiranihOsoba24h");

                    b.Property<decimal>("ProcenatSmrtnosti");

                    b.Property<int>("UkupanBrRegSlucajeva");

                    b.HasKey("Id");

                    b.ToTable("Covid19");
                });
#pragma warning restore 612, 618
        }
    }
}
