using System.Collections.Generic;
using System.Threading.Tasks;
using aspnet_core.models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspnet_core.Controllers
{
    /// <summary>
    /// Course Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CourseController : Controller
    {
        private ICourseCollection _Courses;
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CourseCollection"></param>
        /// <param name="unitOfWork"></param>
        public CourseController(ICourseCollection CourseCollection, IUnitOfWork unitOfWork)
        {
            _Courses = CourseCollection;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _Courses.GetAll();
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Course> Get(string id)
        {
            var allCourses = await _Courses.GetAll();
            return allCourses.Where(i => i.CourseId == id).FirstOrDefault();
        }

        /// <summary>
        /// Add Course
        /// </summary>
        /// <param name="Course"></param>
        [HttpPost]
        public async Task Add([FromBody]Course Course)
        {
            await _Courses.Add(Course);
            await _unitOfWork.Complete();
        }

        /// <summary>
        /// Update Course
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Course Course)
        {
            await _Courses.Update(Course);
            await _unitOfWork.Complete();
        }

        /// <summary>
        /// Remove Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Remove(string id)
        {
            var Courses = await _Courses.GetAll();
            var Course = Courses.FirstOrDefault(i => i.CourseId == id);
            if (Course != null)
            {
                await _Courses.Remove(Course);
                await _unitOfWork.Complete();
            }
        }
    }
}