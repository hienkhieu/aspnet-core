using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_core.models
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Course Id
        /// </summary>
        /// <returns></returns>
        [Key]
        public string CourseId { get; set; }
        /// <summary>
        /// Course name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// Course level
        /// </summary>
        /// <returns></returns>
        public int Level { get; set; }
        /// <summary>
        /// FK teacher id
        /// </summary>
        /// <returns></returns>
        public int TeacherId { get; set; }
        /// <summary>
        /// Teacher
        /// </summary>
        /// <returns></returns>
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}