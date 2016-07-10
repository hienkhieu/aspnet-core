using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_core.models
{
    /// <summary>
    /// Course collection class
    /// </summary>
    public class CourseCollection : ICourseCollection
    {
        private DataContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        public CourseCollection(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(Course item)
        {
            _context.Courses.Add(item);
        }

        /// <summary>
        /// Find with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<Course> Find(Func<Course, bool> predicate)
        {
            return _context.Courses.Where(predicate).ToList();
        }

        /// <summary>
        /// Remove item
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Course item)
        {
            _context.Courses.Remove(item);
        }
    }
}
