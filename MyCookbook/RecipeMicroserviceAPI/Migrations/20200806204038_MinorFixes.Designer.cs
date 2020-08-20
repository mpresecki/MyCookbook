﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeMicroserviceAPI.Data;

namespace RecipeMicroserviceAPI.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20200806204038_MinorFixes")]
    partial class MinorFixes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.MyCookbook", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SavedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Cookbooks");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.PreparationStep", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.Property<string>("StepText")
                        .IsRequired()
                        .HasColumnType("nvarchar(550)")
                        .HasMaxLength(550);

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("PreparationSteps");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CookingTime")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<long>("RecipeCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("Servings")
                        .HasColumnType("bigint");

                    b.Property<long>("SkillLevelId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipeCategoryId");

                    b.HasIndex("SkillLevelId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.RecipeCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.RecipeIngredient", b =>
                {
                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<long>("IngredientId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("UnitId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.SkillLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SkillLevels");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("UnitType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.MyCookbook", b =>
                {
                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.PreparationStep", b =>
                {
                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.Recipe", "Recipe")
                        .WithMany("PreparationSteps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.Recipe", b =>
                {
                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.RecipeCategory", "RecipeCategory")
                        .WithMany()
                        .HasForeignKey("RecipeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeMicroserviceAPI.Data.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeMicroserviceAPI.Data.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
