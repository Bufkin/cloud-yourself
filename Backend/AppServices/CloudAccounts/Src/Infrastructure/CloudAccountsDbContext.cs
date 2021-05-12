﻿using CloudYourself.Backend.AppServices.CloudAccounts.Aggregates.CloudAccount;
using CloudYourself.Backend.AppServices.CloudAccounts.Aggregates.Tenant;
using Microsoft.EntityFrameworkCore;

namespace CloudYourself.Backend.AppServices.CloudAccounts.Infrastructure
{
    /// <summary>
    /// The cloud accounts db context containing all aggregates.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class CloudAccountsDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudAccountsDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CloudAccountsDbContext(DbContextOptions<CloudAccountsDbContext> options) : base(options)
        { }

        /// <summary>
        /// Gets or sets the tenants.
        /// </summary>
        /// <value>
        /// The tenants.
        /// </value>
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the cloud accounts.
        /// </summary>
        /// <value>
        /// The cloud accounts.
        /// </value>
        public DbSet<CloudAccount> CloudAccounts { get; set; }

        /// <summary>
        /// Called by the contex to define th schema.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>().OwnsOne(t => t.BaseData);

            modelBuilder.Entity<CloudAccount>().OwnsOne(ca => ca.BaseData);
            modelBuilder.Entity<CloudAccount>().HasOne<Tenant>().WithMany().HasForeignKey(ca => ca.TenantId);
        }
    }
}
