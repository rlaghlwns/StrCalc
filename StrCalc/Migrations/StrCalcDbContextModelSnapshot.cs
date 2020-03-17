﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrCalc.DataContext;

namespace StrCalc.Migrations
{
    [DbContext(typeof(StrCalcDbContext))]
    partial class StrCalcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StrCalc.Models.Member", b =>
                {
                    b.Property<int>("No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pw")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("No");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("StrCalc.Models.Performance", b =>
                {
                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<float>("BP")
                        .HasColumnType("real");

                    b.Property<string>("Big3Weight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DL")
                        .HasColumnType("real");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("SQT")
                        .HasColumnType("real");

                    b.Property<float>("WP")
                        .HasColumnType("real");

                    b.Property<string>("WR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("No");

                    b.ToTable("MPfmc");
                });

            modelBuilder.Entity("StrCalc.Models.Performance", b =>
                {
                    b.HasOne("StrCalc.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("No")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
