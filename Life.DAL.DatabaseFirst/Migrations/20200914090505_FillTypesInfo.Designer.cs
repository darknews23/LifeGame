﻿// <auto-generated />
using System;
using Life.DAL.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Life.DAL.DatabaseFirst.Migrations
{
    [DbContext(typeof(LifeGameDBContext))]
    [Migration("20200914090505_FillTypesInfo")]
    partial class FillTypesInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<bool?>("BecameAdult")
                        .HasColumnType("bit");

                    b.Property<int?>("DirectionId")
                        .HasColumnType("int");

                    b.Property<int?>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("GameObjectId1")
                        .HasColumnType("int");

                    b.Property<int?>("GameObjectId2")
                        .HasColumnType("int");

                    b.Property<int?>("HpChange")
                        .HasColumnType("int");

                    b.Property<int?>("MoveTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.GameObjectsSessionTypes", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int?>("AdultAge")
                        .HasColumnType("int");

                    b.Property<int?>("BirthTime")
                        .HasColumnType("int");

                    b.Property<int?>("InitialHp")
                        .HasColumnType("int");

                    b.Property<int?>("MaxBirth")
                        .HasColumnType("int");

                    b.HasKey("TypeName", "SessionId");

                    b.ToTable("GameObjectsSessionTypes");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.GameObjectsStepState", b =>
                {
                    b.Property<int>("GameObjectId")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentAge")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentPregnancyTime")
                        .HasColumnType("int");

                    b.Property<int?>("GenderTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPregnant")
                        .HasColumnType("bit");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("GameObjectId", "TypeName", "StepId");

                    b.HasIndex("StepId");

                    b.ToTable("GameObjectsStepState");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.GameObjectsTypes", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool?>("IsEverGrowing")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFullyEatable")
                        .HasColumnType("bit");

                    b.HasKey("TypeName");

                    b.ToTable("GameObjectsTypes");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.GameTiles", b =>
                {
                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.Property<int>("AreaTypeId")
                        .HasColumnType("int");

                    b.HasKey("StepId", "X", "Y")
                        .HasName("PK_GameTiles_1");

                    b.ToTable("GameTiles");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.SessionPartiallyEatableTypes", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("BeingEatenDamage")
                        .HasColumnType("int");

                    b.HasKey("TypeName", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionPartiallyEatableTypes");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.SessionTypesMoveTypes", b =>
                {
                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("MoveTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("TypeName", "MoveTypeId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionTypesMoveTypes");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.Sessions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.Steps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.Events", b =>
                {
                    b.HasOne("Life.DAL.DatabaseFirst.Models.Steps", "Step")
                        .WithMany("Events")
                        .HasForeignKey("StepId")
                        .HasConstraintName("FK_Events_Steps")
                        .IsRequired();
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.GameObjectsStepState", b =>
                {
                    b.HasOne("Life.DAL.DatabaseFirst.Models.Steps", "Step")
                        .WithMany("GameObjectsStepState")
                        .HasForeignKey("StepId")
                        .HasConstraintName("FK_GameObjectsStepState_Steps")
                        .IsRequired();
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.GameTiles", b =>
                {
                    b.HasOne("Life.DAL.DatabaseFirst.Models.Steps", "Step")
                        .WithMany("GameTiles")
                        .HasForeignKey("StepId")
                        .HasConstraintName("FK_GameTiles_Steps")
                        .IsRequired();
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.SessionPartiallyEatableTypes", b =>
                {
                    b.HasOne("Life.DAL.DatabaseFirst.Models.Sessions", "Session")
                        .WithMany("SessionPartiallyEatableTypes")
                        .HasForeignKey("SessionId")
                        .HasConstraintName("FK_SessionPartiallyEatableTypes_Sessions")
                        .IsRequired();
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.SessionTypesMoveTypes", b =>
                {
                    b.HasOne("Life.DAL.DatabaseFirst.Models.Sessions", "Session")
                        .WithMany("SessionTypesMoveTypes")
                        .HasForeignKey("SessionId")
                        .HasConstraintName("FK_SessionTypesMoveTypes_Sessions")
                        .IsRequired();
                });

            modelBuilder.Entity("Life.DAL.DatabaseFirst.Models.Steps", b =>
                {
                    b.HasOne("Life.DAL.DatabaseFirst.Models.Sessions", "Session")
                        .WithMany("Steps")
                        .HasForeignKey("SessionId")
                        .HasConstraintName("FK_Steps_Sessions")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
