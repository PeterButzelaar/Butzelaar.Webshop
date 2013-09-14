using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using Butzelaar.Generic.Logging;
using Butzelaar.Generic.Logging.Enumeration;
using Butzelaar.Webshop.Database.Entities.Logging;

namespace Butzelaar.Webshop.Database
{
    /// <summary>
    /// Database context for security database
    /// </summary>
    public class LoggingContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingContext"/> class.
        /// </summary>
        public LoggingContext()
            : base(ConfigurationManager.ConnectionStrings["Logging"].ConnectionString)
        {
        }

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
            #region Log

            Logger.Log(Level.Debug, "Mapping logging database");

            modelBuilder.Entity<Log>()
                        .Map(m => m.ToTable("Log"))
                        .HasEntitySetName("Logs");
            modelBuilder.Entity<Log>()
                        .HasKey(m => m.Id)
                        .Property(m => m.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Date)
                        .HasColumnType("datetime2")
                        .IsRequired();
            modelBuilder.Entity<Log>()
                        .Property(m => m.Thread)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(255);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Level)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(50);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Host)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(50);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Logger)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(255);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Message)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(2000);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Details)
                        .IsVariableLength()
                        .HasMaxLength(4000);
            modelBuilder.Entity<Log>()
                        .Property(m => m.Exception)
                        .IsVariableLength()
                        .HasMaxLength(2000);
            modelBuilder.Entity<Log>()
                        .Property(m => m.StackTrace)
                        .IsVariableLength()
                        .IsRequired()
                        .HasMaxLength(4000);

            Logger.Log(Level.Debug, "Mapped Log class");

            #endregion
        }

        #region Collections

        /// <summary>
        /// Gets or sets the menus.
        /// </summary>
        /// <value>
        /// The menus.
        /// </value>
        public DbSet<Log> Logs { get; set; }

        #endregion
    }
}