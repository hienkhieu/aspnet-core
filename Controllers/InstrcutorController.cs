using System.Collections.Generic;
using aspnet_core.models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core.Controllers
{
    /// <summary>
    /// Instructor Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InstructorController: Controller
    {
        private ITeacherCollection _instructors;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="instructorCollection"></param> 
        /// <param name="unitOfWork"></param>
        public InstructorController(ITeacherCollection instructorCollection, IUnitOfWork unitOfWork)
        {
            _instructors = instructorCollection;
        }
    }
}