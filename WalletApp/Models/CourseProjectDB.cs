using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WalletApp.Models
{
    public partial class CourseProjectDB : DbContext
    {
        public CourseProjectDB()
            : base("name=CourseProjectDB3")
        {
        }

        public virtual DbSet<budget_periods> budget_periods { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<savings_goals> savings_goals { get; set; }
        public virtual DbSet<savings_transfers> savings_transfers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<transactions> transactions { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<budget_periods>()
                .Property(e => e.planned_budget)
                .HasPrecision(12, 2);

            modelBuilder.Entity<categories>()
                .HasMany(e => e.categories1)
                .WithOptional(e => e.categories2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<categories>()
                .HasMany(e => e.transactions)
                .WithRequired(e => e.categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<savings_goals>()
                .Property(e => e.target_amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<savings_goals>()
                .HasMany(e => e.savings_transfers)
                .WithRequired(e => e.savings_goals)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<savings_transfers>()
                .Property(e => e.amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<transactions>()
                .Property(e => e.amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<users>()
                .HasMany(e => e.budget_periods)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.savings_goals)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.transactions)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);
        }
    }
}
