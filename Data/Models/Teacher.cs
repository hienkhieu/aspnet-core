using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnet_core.models
{
    /// <summary>
    /// Teacher
    /// </summary>
    public class Teacher    
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Key]
        public int TeacherId { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        /// <returns></returns>
        public string Firstname { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        /// <returns></returns>
        public string Lastname { get; set; }
        /// <summary>
        /// Age
        /// </summary>
        /// <returns></returns>
        public int Age { get; set; }
        /// <summary>
        /// Courses to be taught
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Course> Courses { get; set; }     
    }
}