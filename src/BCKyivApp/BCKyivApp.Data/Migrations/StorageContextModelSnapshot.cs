using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BCKyivApp.Data;

namespace BCKyivApp.Data.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("BCKyivApp.Data.Entities.Centre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.ToTable("Centres");
                });

            modelBuilder.Entity("BCKyivApp.Data.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CentreId");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("Skype");

                    b.HasKey("Id");

                    b.HasIndex("CentreId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("BCKyivApp.Data.Entities.Contact", b =>
                {
                    b.HasOne("BCKyivApp.Data.Entities.Centre", "Centre")
                        .WithMany("Contacts")
                        .HasForeignKey("CentreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
