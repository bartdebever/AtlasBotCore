﻿// <auto-generated />
using DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataLibrary.Migrations
{
    [DbContext(typeof(RiotData))]
    partial class RiotDataModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLibrary.Champion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChampionId");

                    b.Property<int?>("infoId");

                    b.Property<string>("key");

                    b.Property<string>("lore");

                    b.Property<string>("name");

                    b.Property<int?>("passiveId");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.HasIndex("infoId");

                    b.HasIndex("passiveId");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("DataLibrary.ChampionSpellDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChampionId");

                    b.Property<string>("EffectBurn");

                    b.Property<string>("cooldownBurn");

                    b.Property<string>("costType");

                    b.Property<string>("key");

                    b.Property<string>("name");

                    b.Property<string>("resource");

                    b.Property<string>("sanitizedDescription");

                    b.Property<string>("sanitizedTooltip");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("DataLibrary.coeff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("value");

                    b.Property<int?>("varsid");

                    b.HasKey("Id");

                    b.HasIndex("varsid");

                    b.ToTable("coeff");
                });

            modelBuilder.Entity("DataLibrary.PassiveDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<string>("sanitizedDescription");

                    b.HasKey("Id");

                    b.ToTable("Passives");
                });

            modelBuilder.Entity("DataLibrary.Riot.Item.GoldDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Base");

                    b.Property<bool>("purchasable");

                    b.Property<int>("sell");

                    b.Property<int>("total");

                    b.HasKey("Id");

                    b.ToTable("GoldDto");
                });

            modelBuilder.Entity("DataLibrary.Riot.Item.ItemDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemId");

                    b.Property<bool>("consumed");

                    b.Property<string>("description");

                    b.Property<int?>("goldId");

                    b.Property<string>("group");

                    b.Property<bool>("inStore");

                    b.Property<string>("name");

                    b.Property<string>("plaintext");

                    b.Property<string>("requiredChampion");

                    b.Property<int>("stacks");

                    b.HasKey("Id");

                    b.HasIndex("goldId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DataLibrary.SkinDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChampionId");

                    b.Property<string>("name");

                    b.Property<int>("num");

                    b.Property<int>("skinId");

                    b.HasKey("Id");

                    b.HasIndex("ChampionId");

                    b.ToTable("Skins");
                });

            modelBuilder.Entity("DataLibrary.StatsDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("attack");

                    b.Property<int>("defense");

                    b.Property<int>("difficulty");

                    b.Property<int>("magic");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("DataLibrary.vars", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChampionSpellDtoId");

                    b.Property<string>("key");

                    b.HasKey("id");

                    b.HasIndex("ChampionSpellDtoId");

                    b.ToTable("vars");
                });

            modelBuilder.Entity("DataLibrary.Champion", b =>
                {
                    b.HasOne("DataLibrary.StatsDto", "info")
                        .WithMany()
                        .HasForeignKey("infoId");

                    b.HasOne("DataLibrary.PassiveDto", "passive")
                        .WithMany()
                        .HasForeignKey("passiveId");
                });

            modelBuilder.Entity("DataLibrary.ChampionSpellDto", b =>
                {
                    b.HasOne("DataLibrary.Champion")
                        .WithMany("spells")
                        .HasForeignKey("ChampionId");
                });

            modelBuilder.Entity("DataLibrary.coeff", b =>
                {
                    b.HasOne("DataLibrary.vars")
                        .WithMany("Coeff")
                        .HasForeignKey("varsid");
                });

            modelBuilder.Entity("DataLibrary.Riot.Item.ItemDto", b =>
                {
                    b.HasOne("DataLibrary.Riot.Item.GoldDto", "gold")
                        .WithMany()
                        .HasForeignKey("goldId");
                });

            modelBuilder.Entity("DataLibrary.SkinDto", b =>
                {
                    b.HasOne("DataLibrary.Champion")
                        .WithMany("skins")
                        .HasForeignKey("ChampionId");
                });

            modelBuilder.Entity("DataLibrary.vars", b =>
                {
                    b.HasOne("DataLibrary.ChampionSpellDto")
                        .WithMany("vars")
                        .HasForeignKey("ChampionSpellDtoId");
                });
#pragma warning restore 612, 618
        }
    }
}
