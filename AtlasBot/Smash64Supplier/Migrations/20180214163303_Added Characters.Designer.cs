﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Smash64Supplier;
using System;

namespace Smash64Supplier.Migrations
{
    [DbContext(typeof(_64Context))]
    [Migration("20180214163303_Added Characters")]
    partial class AddedCharacters
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Smash64Supplier.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BrakingForce");

                    b.Property<double>("DashDeceleration");

                    b.Property<int>("InitialDashFrames");

                    b.Property<double>("InitialDashSpeed");

                    b.Property<int>("JumpAnimationFrames");

                    b.Property<int>("MaxNumberOfJumps");

                    b.Property<string>("Name");

                    b.Property<double>("RunningSpeed");

                    b.Property<double>("WalkingSpeed");

                    b.Property<double>("Weight");

                    b.Property<double>("XAirAcceleration");

                    b.Property<double>("XAirMaxSpeed");

                    b.Property<double>("XAirResistance");

                    b.Property<double>("YFallAcceleration");

                    b.Property<double>("YMaxFastFallSpeed");

                    b.Property<double>("YMaxSpeedFall");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
