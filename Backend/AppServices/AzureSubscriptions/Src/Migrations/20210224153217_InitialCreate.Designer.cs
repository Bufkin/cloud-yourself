﻿// <auto-generated />
using CloudYourself.Backend.AppServices.AzureSubscriptions.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudYourself.Backend.AppServices.AzureSubscriptions.Migrations
{
    [DbContext(typeof(AzureSubscriptionsDbContext))]
    [Migration("20210224153217_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Subscription.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CloudAccountId")
                        .HasColumnType("int");

                    b.Property<string>("CreationOperationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Tennant.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Subscription.Subscription", b =>
                {
                    b.HasOne("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Tennant.Tenant", null)
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Tennant.Tenant", b =>
                {
                    b.OwnsOne("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Tennant.AppRegistration", "AppRegistration", b1 =>
                        {
                            b1.Property<int>("TenantId")
                                .HasColumnType("int");

                            b1.Property<string>("AzureAppRegistrationId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AzureAppSecret")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AzureDirectoryTenantId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TenantId");

                            b1.ToTable("Tenants");

                            b1.WithOwner()
                                .HasForeignKey("TenantId");
                        });

                    b.OwnsOne("CloudYourself.Backend.AppServices.AzureSubscriptions.Aggregates.Tennant.ManagementTarget", "ManagementTarget", b1 =>
                        {
                            b1.Property<int>("TenantId")
                                .HasColumnType("int");

                            b1.Property<string>("EnrollmentAccountId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ManagementGroupId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TenantId");

                            b1.ToTable("Tenants");

                            b1.WithOwner()
                                .HasForeignKey("TenantId");
                        });

                    b.Navigation("AppRegistration");

                    b.Navigation("ManagementTarget");
                });
#pragma warning restore 612, 618
        }
    }
}
