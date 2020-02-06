using Domain;
using Domain.Model;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataContext : DbContext, IDbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<HistoryPurchaseHosting> HistoryPurchaseHostings { get; set; }
        public virtual DbSet<Hosting> Hostings { get; set; }
        public virtual DbSet<PermissionRecord> PermissionRecords { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
    }
}
