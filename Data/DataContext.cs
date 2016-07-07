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
        /// Teachers
        /// </summary>
        /// <returns></returns>
        public DbSet<Teacher> Teachers {get; set;}
        /// <summary>
        /// Courses
        /// </summary>
        /// <returns></returns>
        public DbSet<Course> Courses { get; set; }
    }
}