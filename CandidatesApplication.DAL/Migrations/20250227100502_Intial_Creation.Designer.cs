﻿// <auto-generated />
using System;
using CandidatesApplication.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CandidatesApplication.DAL.Migrations
{
    [DbContext(typeof(CandidateAppContext))]
    [Migration("20250227100502_Intial_Creation")]
    partial class Intial_Creation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CandidatesApplication.DAL.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxNumSkills")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("CandidatesApplication.DAL.Models.CandidateHasSkill", b =>
                {
                    b.Property<int>("Candidate_Id")
                        .HasColumnType("int");

                    b.Property<int>("Skill_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("GainedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Candidate_Id", "Skill_Id");

                    b.HasIndex("Skill_Id");

                    b.ToTable("CandidateHasSkills");
                });

            modelBuilder.Entity("CandidatesApplication.DAL.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CandidatesApplication.DAL.Models.CandidateHasSkill", b =>
                {
                    b.HasOne("CandidatesApplication.DAL.Models.Candidate", "Candidate")
                        .WithMany("CandidateHasSkill_list")
                        .HasForeignKey("Candidate_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CandidatesApplication.DAL.Models.Skill", "Skill")
                        .WithMany("CandidateHasSkill_list")
                        .HasForeignKey("Skill_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("CandidatesApplication.DAL.Models.Candidate", b =>
                {
                    b.Navigation("CandidateHasSkill_list");
                });

            modelBuilder.Entity("CandidatesApplication.DAL.Models.Skill", b =>
                {
                    b.Navigation("CandidateHasSkill_list");
                });
#pragma warning restore 612, 618
        }
    }
}
