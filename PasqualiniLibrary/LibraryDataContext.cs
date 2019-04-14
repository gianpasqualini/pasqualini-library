using Microsoft.EntityFrameworkCore;
using PasqualiniLibrary.DataModel;

namespace LibraryDataModel
{
    public class LibraryDataContext: DbContext
    {
        public DbSet<Book> Books { get;  set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\LibraryDatabase;Initial Catalog=dbo;Integrated Security=SSPI;");
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}

