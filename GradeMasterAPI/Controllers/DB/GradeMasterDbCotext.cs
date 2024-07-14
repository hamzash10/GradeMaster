using Microsoft.EntityFrameworkCore;


//Operations on DBSET collections will be reflected on the DB without using SQL syntax
namespace GradeMasterAPI.Controllers.DB
{
    public class GradeMasterDbContext : DbContext
    {
        public GradeMasterDbContext(DbContextOptions<GradeMasterDbContext> options) : base(options)
        {
           
        }

        // i added the connectionstring in Program.cs

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=HAMZASH\\SQLEXPRESS;Initial Catalog=GradeMAsterDB;Integrated Security=True;Connect Timeout=30;");
        //    //base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //base.OnModelCreating(modelBuilder);
        }

        //Collection Sync with DB
        //related students table
        public DbSet<DBModels.Student> Students {  get; set; }
        //related teachers table
        public DbSet<DBModels.Teacher> Teachers { get; set; }
        //related courses table
        public DbSet<DBModels.Course> Courses { get; set; }

    }
}
