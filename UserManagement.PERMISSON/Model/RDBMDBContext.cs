namespace UserManagement.PERMISSON.Model
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

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Group_Permissions> Group_Permissions { get; set; }
        public virtual DbSet<Group_Roles> Group_Roles { get; set; }
        public virtual DbSet<Group_Users> Group_Users { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Role_Permissions> Role_Permissions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreatorID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Permissions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreatorID);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Permissions1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.Modifier);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.CreatorID);
        }
    }
}
