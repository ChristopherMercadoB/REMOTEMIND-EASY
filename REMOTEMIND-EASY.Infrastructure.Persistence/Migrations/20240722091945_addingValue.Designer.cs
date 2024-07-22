﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;

#nullable disable

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240722091945_addingValue")]
    partial class addingValue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("REMOTEMIND_EASY.Core.Domain.Entities.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Preguntas", (string)null);
                });

            modelBuilder.Entity("REMOTEMIND_EASY.Core.Domain.Entities.Responses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Respuestas", (string)null);
                });

            modelBuilder.Entity("REMOTEMIND_EASY.Core.Domain.Entities.UserResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("ResponseId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("ResponseId");

                    b.ToTable("RespuestaDeUsuario", (string)null);
                });

            modelBuilder.Entity("REMOTEMIND_EASY.Core.Domain.Entities.UserResponse", b =>
                {
                    b.HasOne("REMOTEMIND_EASY.Core.Domain.Entities.Questions", "Question")
                        .WithMany("UserResponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("REMOTEMIND_EASY.Core.Domain.Entities.Responses", "Response")
                        .WithMany("UserResponses")
                        .HasForeignKey("ResponseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Response");
                });

            modelBuilder.Entity("REMOTEMIND_EASY.Core.Domain.Entities.Questions", b =>
                {
                    b.Navigation("UserResponses");
                });

            modelBuilder.Entity("REMOTEMIND_EASY.Core.Domain.Entities.Responses", b =>
                {
                    b.Navigation("UserResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
