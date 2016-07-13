using System.Threading.Tasks;

namespace aspnet_core.models
{
    /// <summary>
    /// UnitOfWork class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Complete unit of work
        /// </summary>
        public Task Complete()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Course collection
        /// </summary>
        /// <returns></returns>
        public CourseCollection CourseCollection { get; set; }

        /// <summary>
        /// Teacher collection
        /// </summary>
        /// <returns></returns>
        public InstructorCollection TeacherCollection { get; set; }
    }
}