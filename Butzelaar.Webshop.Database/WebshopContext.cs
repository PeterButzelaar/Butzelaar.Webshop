using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Butzelaar.Webshop.Database.Entities.Webshop;
using Butzelaar.Generic.Logging;
using Butzelaar.Generic.Logging.Enumeration;

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
            : base(ConfigurationManager.ConnectionStrings["Webshop"].ConnectionString)
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

            Logger.Log(Level.Debug, "Mapping webshop database");

            modelBuilder.Entity<Menu>()
                        .Map(m => m.ToTable("Menu"))
                        .HasEntitySetName("Menus")
                        .HasOptional(m => m.Parent)
                        .WithMany(m => m.Children)
                        .HasForeignKey(m => m.ParentId);
            modelBuilder.Entity<Menu>()
                        .Property(m => m.Name)
                        .IsVariableLength()
                        .HasMaxLength(50);
            SetDefaultModelProperties<Menu>(modelBuilder);

            Logger.Log(Level.Debug, "Mapped Menu class");

            #endregion

            #region User

            modelBuilder.Entity<User>()
                        .Map(u => u.ToTable("User"))
                        .HasEntitySetName("Users")
                        .Property(u => u.FirstName)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(50);
            SetDefaultModelProperties<User>(modelBuilder);

            Logger.Log(Level.Debug, "Mapped User class");

            #endregion
        }

        /// <summary>
        /// Sets the default model properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelBuilder">The model builder.</param>
        private static void SetDefaultModelProperties<T>(DbModelBuilder modelBuilder) where T : Base
        {
            modelBuilder.Entity<T>()
                        .HasKey(m => m.Id)
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
            return
                (from e in ChangeTracker.Entries<T>()
                 where e.State == EntityState.Added || e.State == EntityState.Modified
                 select e)
                ;
        }

        #endregion

        #region Collections

        /// <summary>
        /// Gets or sets the menus.
        /// </summary>
        /// <value>
        /// The menus.
        /// </value>
        public DbSet<Menu> Menus { get; set; }

        #endregion
    }
}
