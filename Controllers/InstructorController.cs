using System.Collections.Generic;
using System.Threading.Tasks;
using aspnet_core.models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace aspnet_core.Controllers
{
    /// <summary>
    /// Instructor Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InstructorController : Controller
    {
        private IInstructorCollection _instructors;
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="instructorCollection"></param>
        /// <param name="unitOfWork"></param>
        public InstructorController(IInstructorCollection instructorCollection, IUnitOfWork unitOfWork)
        {
            _instructors = instructorCollection;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all instructors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await _instructors.GetAll();
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Instructor> Get(int id)
        {
            var allInstructors = await _instructors.GetAll();
            return allInstructors.Where(i => i.InstructorId == id).FirstOrDefault();
        }

        /// <summary>
        /// Add instructor
        /// </summary>
        /// <param name="instructor"></param>
        [HttpPost]
        public async Task Add([FromBody]Instructor instructor)
        {
            await _instructors.Add(instructor);
            await _unitOfWork.Complete();
        }

        /// <summary>
        /// Update instructor
        /// </summary>
        /// <param name="instructor"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update([FromBody] Instructor instructor)
        {
            await _instructors.Update(instructor);
            await _unitOfWork.Complete();
        }

        /// <summary>
        /// Remove Instructor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            var instructors = await _instructors.GetAll();
            var instructor = instructors.FirstOrDefault(i => i.InstructorId == id);
            if (instructor != null)
            {
                await _instructors.Remove(instructor);
                await _unitOfWork.Complete();
            }
        }
    }
}