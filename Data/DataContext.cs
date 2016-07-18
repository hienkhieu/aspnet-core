using Microsoft.EntityFrameworkCore;
using aspnet_core.models;

namespace aspnet_core
{
    /// <summary>
    /// DataContext
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DataContext(){}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options):base(options"></param>
        public DataContext(DbContextOptions options):base(options){}

        /// <summary>
        /// Instructors
        /// </summary>
        /// <returns></returns>
        public virtual DbSet<Instructor> Instructors {get; set;}
        /// <summary>
        /// Courses
        /// </summary>
        /// <returns></returns>
        public virtual DbSet<Course> Courses { get; set; }
    }
}