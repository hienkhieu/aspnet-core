using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_core.models
{
    /// <summary>
    /// Teacher collection
    /// </summary>
    public class TeacherCollection : ITeacherCollection
    {
        private DataContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public TeacherCollection(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add teacher
        /// </summary>
        /// <param name="item"></param>
        public void Add(Teacher item)
        {
            _context.Teachers.Add(item);
        }

        /// <summary>
        /// Find teachers
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<Teacher> Find(Func<Teacher, bool> predicate)
        {
            return _context.Teachers.Where(predicate).ToList();
        }

        /// <summary>
        /// Remove teacher
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Teacher item)
        {
            _context.Teachers.Remove(item);
        }
    }
}