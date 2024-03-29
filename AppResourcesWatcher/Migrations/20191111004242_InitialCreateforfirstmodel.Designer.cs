﻿// <auto-generated />
using AppResourcesWatcher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppResourcesWatcher.Migrations
{
    [DbContext(typeof(MemorySnapShotContext))]
    [Migration("20191111004242_InitialCreateforfirstmodel")]
    partial class InitialCreateforfirstmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppResourcesWatcher.Models.MemorySnapshot", b =>
                {
                    b.Property<int>("MemorySnapshotId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Available");

                    b.Property<int>("BuffCache");

                    b.Property<int>("Free");

                    b.Property<int>("Shared");

                    b.Property<int>("Total");

                    b.Property<int>("Used");

                    b.HasKey("MemorySnapshotId");

                    b.ToTable("MemorySnapshots");
                });
#pragma warning restore 612, 618
        }
    }
}
