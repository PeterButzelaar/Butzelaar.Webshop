using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;
using Butzelaar.Webshop.Database.Entities;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Context for the webshop database
    /// </summary>
    public class WebshopContext : DbContext
    {
        #region Properties

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        private string Username { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WebshopContext"/> class.
        /// </summary>
        public WebshopContext()
            : this("Unknown")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebshopContext"/> class.
        /// </summary>
        public WebshopContext(string username)
            : base("Name=Webshop")
        {
            Username = username;
        }

        #endregion

        #region Override

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Menu

            modelBuilder.Entity<Menu>()
                        .Map(m => m.ToTable("Menu"))
                        .HasEntitySetName("Menus")
                        .HasKey(m => m.Id)
                        .HasOptional(m => m.Parent)
                        .WithMany(m => m.Children)
                        .Map(c => c.MapKey("ParentId"));
            modelBuilder.Entity<Menu>()
                        .Property(m => m.Name)
                        .IsVariableLength()
                        .HasMaxLength(50);
            SetDefaultModelProperties<Menu>(modelBuilder);

            #endregion
        }

        private static void SetDefaultModelProperties<T>(DbModelBuilder modelBuilder) where T : Base
        {
            modelBuilder.Entity<Menu>()
                        .Property(m => m.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<T>()
                        .Property(m => m.CreateDate)
                        .HasColumnType("datetime2")
                        .IsRequired();
            modelBuilder.Entity<T>()
                        .Property(m => m.CreatedBy)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(50);
            modelBuilder.Entity<T>()
                        .Property(m => m.ModifiedDate)
                        .HasColumnType("datetime2")
                        .IsRequired();
            modelBuilder.Entity<T>()
                        .Property(m => m.ModifiedBy)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(50);
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public override int SaveChanges()
        {
            var changeSet = GetChangedEntries<Base>();
            foreach (var entry in changeSet)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        SetCreateProperties(entry.Entity);
                        SetModifiedProperties(entry.Entity);
                        break;
                    case EntityState.Modified:
                        SetModifiedProperties(entry.Entity);
                        break;
                }
            }

            return base.SaveChanges();
        }

        #endregion

        #region Setters

        /// <summary>
        /// Sets the create properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void SetCreateProperties(Base entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            entity.CreatedBy = Username;
        }

        /// <summary>
        /// Sets the modified properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void SetModifiedProperties(Base entity)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ModifiedBy = Username;
        }

        #endregion

        #region Getters

        /// <summary>
        /// Gets the changed entries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private IEnumerable<DbEntityEntry<T>> GetChangedEntries<T>() where T : class
        {
            return ChangeTracker
                .Entries<T>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        }

        #endregion


        /// <summary>
        /// Gets or sets the menus.
        /// </summary>
        /// <value>
        /// The menus.
        /// </value>
        public DbSet<Menu> Menus { get; set; }
    }
}
