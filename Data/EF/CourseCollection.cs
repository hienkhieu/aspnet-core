using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core.models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core.Data.Ef
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
            return await Task.Run(() => _context.Courses.Include(course => course.Instructor).Where(predicate).ToList());
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetAll()
        {
            try
            {
                return await Task.Run(() => _context.Courses.ToList());
            }
            catch (System.Exception e)
            {
                
                throw;
            }
            
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
        /// <param name="newItem"></param>
        /// <returns></returns>
        public async Task Update(Course newItem)
        {
            var oldItem = await Task.Run(() => _context.Courses.FirstOrDefault(p => p.CourseId == newItem.CourseId));
            if (oldItem != null)
                UpdateCourse(newItem, oldItem);
        }

        private void UpdateCourse(Course input, Course output)
        {
            output.Name = input.Name;
            output.InstructorId = input.InstructorId;
        }
    }
}
