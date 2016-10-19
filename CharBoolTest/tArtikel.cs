using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharBoolTest
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;

    [Table("ArticleTest")]
    public class Artikel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kArtikel { get; set; }
        
        public bool cAktiv { get; set; }
        public bool? cAktivNull { get; set; }

        public bool nAktiv { get; set; }
        public bool? nAktivNull { get; set; }

    }

    public class TestContext : DbContext
    {
        static TestContext ()
        {
            Database.SetInitializer<TestContext>(null);
        }
        public TestContext()
            :base(@"Server=.\SQLEXPRESS;Persist Security Info=true;Initial Catalog=ViCtor;User=sa;Password=sa04jT14")
        {
            
        }

        public DbSet<Artikel> Artikel { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns> 
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for 
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">
        /// A database command did not affect the expected number of rows. This usually indicates an optimistic 
        /// concurrency violation; that is, a row has been changed in the database since it was queried.
        /// </exception>
        /// <exception cref="DbEntityValidationException">
        /// The save was aborted because validation of entity property values failed.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// An attempt was made to use unsupported behavior such as executing multiple asynchronous commands concurrently
        /// on the same context instance.</exception>
        /// <exception cref="System.ObjectDisposedException">The context or connection have been disposed.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// Some error occurred attempting to process entities in the context either before or after sending commands
        /// to the database.
        /// </exception>
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        /// <param name="modelBuilder"> The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikel>().Property(x => x.cAktiv).HasColumnName("cAktiv").IsRequired().HasColumnType("charbool").HasColumnAnnotation("TrueValue","Y").HasColumnAnnotation("FalseValue","N");
            modelBuilder.Entity<Artikel>().Property(x => x.cAktivNull).HasColumnName("cAktivNull").HasColumnType("charbool");
            modelBuilder.Entity<Artikel>().Property(x => x.nAktiv).HasColumnName("nAktiv").IsRequired().HasColumnType("tinyintbool");
            modelBuilder.Entity<Artikel>().Property(x => x.nAktivNull).HasColumnName("nAktivNull").HasColumnType("tinyintbool");
            base.OnModelCreating(modelBuilder);
        }


    }
}
