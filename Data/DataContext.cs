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
        /// Instructors
        /// </summary>
        /// <returns></returns>
        public DbSet<Instructor> Instructors {get; set;}
        /// <summary>
        /// Courses
        /// </summary>
        /// <returns></returns>
        public DbSet<Course> Courses { get; set; }
    }
}