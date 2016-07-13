using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task Add(Course item)
        {
           await Task.Run(() => _context.Courses.Add(item));
        }

        /// <summary>
        /// Find with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> Find(Func<Course, bool> predicate)
        {
            return await Task.Run(() => _context.Courses.Where(predicate).ToList());
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await Task.Run(() => _context.Courses.ToList());
        }

        /// <summary>
        /// Remove item
        /// </summary>
        /// <param name="item"></param>
        public async Task Remove(Course item)
        {
            await Task.Run(() => _context.Courses.Remove(item));
        }

 
        /// <summary>
        /// Update Course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task Update(Course course)
        {
            var item = await Task.Run(() => _context.Courses.FirstOrDefault(p => p.CourseId == course.CourseId));
            if (item != null)
                UpdateCourse(item, course);
        }

        private void UpdateCourse(Course input, Course output)
        {
            output.Name = input.Name;
            output.Instructor = input.Instructor;
            output.InstructorId = input.InstructorId;
        }
    }
}
