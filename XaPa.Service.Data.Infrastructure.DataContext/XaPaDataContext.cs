using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Data.Infrastructure.DataContext
{
    public class XaPaDataContext : DbContext
    {
        #region OldDataContext
        //public XaPaDataContext()
        //    : base("name=XaPaDataContext")
        //{
        //}

        //public virtual DbSet<Categories> Categories { get; set; }
        //public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        //public virtual DbSet<Orders> Orders { get; set; }
        //public virtual DbSet<ProductImages> ProductImages { get; set; }
        //public virtual DbSet<Products> Products { get; set; }
        //public virtual DbSet<Users> Users { get; set; }
        //public virtual DbSet<UserTitles> UserTitles { get; set; }
        //public virtual DbSet<UserTokens> UserTokens { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Categories>()
        //        .HasMany(e => e.Products)
        //        .WithRequired(e => e.Categories)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Orders>()
        //        .HasOptional(e => e.OrderDetails)
        //        .WithRequired(e => e.Orders);

        //    modelBuilder.Entity<Products>()
        //        .Property(e => e.UnitPrice)
        //        .HasPrecision(8, 2);

        //    modelBuilder.Entity<Products>()
        //        .HasMany(e => e.OrderDetails)
        //        .WithRequired(e => e.Products)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Products>()
        //        .HasOptional(e => e.ProductImages)
        //        .WithRequired(e => e.Products);

        //    modelBuilder.Entity<Users>()
        //        .Property(e => e.Phone)
        //        .IsFixedLength()
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Users>()
        //        .Property(e => e.UserPassword)
        //        .IsFixedLength()
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.Orders)
        //        .WithRequired(e => e.Users)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Users>()
        //        .HasMany(e => e.UserTokens)
        //        .WithRequired(e => e.Users)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<UserTitles>()
        //        .Property(e => e.UserTitleName)
        //        .IsFixedLength()
        //        .IsUnicode(false);

        //    modelBuilder.Entity<UserTitles>()
        //        .HasMany(e => e.Users)
        //        .WithRequired(e => e.UserTitles)
        //        .HasForeignKey(e => e.UserTitle)
        //        .WillCascadeOnDelete(false);
        //} 
        #endregion

        public XaPaDataContext()
            : base("name=XaPaDataContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserTitles> UserTitles { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasOptional(e => e.OrderDetails)
                .WithRequired(e => e.Orders);

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Products)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasOptional(e => e.ProductImages)
                .WithRequired(e => e.Products);

            modelBuilder.Entity<Users>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserTokens)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTitles>()
                .Property(e => e.UserTitleName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserTitles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserTitles)
                .HasForeignKey(e => e.UserTitle)
                .WillCascadeOnDelete(false);
        }
    }
}