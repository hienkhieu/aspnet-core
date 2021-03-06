using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core.models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core.Data.Ef
{
    /// <summary>
    /// Teacher collection
    /// </summary>
    public class InstructorCollection : IInstructorCollection
    {
        private DataContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public InstructorCollection(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add teacher
        /// </summary>
        /// <param name="item"></param>
        public async Task Add(Instructor item)
        {
            await Task.Run(() => _context.Instructors.Add(item));
        }

        /// <summary>
        /// Find teachers
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Instructor>> Find(Func<Instructor, bool> predicate)
        {
            return await Task.Run(() => _context.Instructors.Include(i => i.Courses).Where(predicate).ToList());
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await Task.Run(() => _context.Instructors.ToList());
        }

        /// <summary>
        /// Remove teacher
        /// </summary>
        /// <param name="item"></param>
        public async Task Remove(Instructor item)
        {
           await Task.Run(() => _context.Instructors.Remove(item));
        }

        /// <summary>
        /// Update Instructor
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public async Task Update(Instructor newItem)
        {
            var oldItem = await Task.Run(() => _context.Instructors.FirstOrDefault(p => p.InstructorId == newItem.InstructorId));
            if (oldItem != null)
                UpdateCourse(newItem, oldItem);
        }

        private void UpdateCourse(Instructor input, Instructor output)
        {
            output.Firstname = input.Firstname;
            output.Lastname = input.Lastname;
            output.Age = input.Age;
            output.InstructorId = input.InstructorId;
            output.Courses = input.Courses;
        }
    }
}