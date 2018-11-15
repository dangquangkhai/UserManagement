namespace UserManagement.LIBRARY.RDBMModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RDBMDBContext : DbContext
    {
        public RDBMDBContext()
            : base("name=RDBMDBContext")
        {
        }

        public virtual DbSet<Monthly_Schedule> Monthly_Schedule { get; set; }
        public virtual DbSet<PaymentPerDay> PaymentPerDays { get; set; }
        public virtual DbSet<Roll_Call> Roll_Call { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monthly_Schedule>()
                .HasMany(e => e.Salaries)
                .WithOptional(e => e.Monthly_Schedule)
                .HasForeignKey(e => e.MonthID);

            modelBuilder.Entity<PaymentPerDay>()
                .Property(e => e.Money)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PaymentPerDay>()
                .Property(e => e.Allowance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PaymentPerDay>()
                .HasMany(e => e.Salaries)
                .WithOptional(e => e.PaymentPerDay)
                .HasForeignKey(e => e.PayMentOfUserID);

            modelBuilder.Entity<Salary>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
