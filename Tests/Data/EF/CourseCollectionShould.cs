using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using aspnet_core.Data.Ef;
using aspnet_core.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace aspnet_core.tests
{
    /// <summary>
    /// CourseCollectionShould
    /// </summary>
    [TestClass]
    public class CourseCollectionShould
    {
        private IQueryable<Course> data;

        /// <summary>
        /// Constructor
        /// </summary>
        public CourseCollectionShould()
        {
            data = new List<Course>{
                new Course{ CourseId = "Math101", Name = "Math 101", Level = 100, InstructorId = 2},
                new Course{ CourseId = "Eng101", Name = "English 101", Level = 100, InstructorId = 1}
            }.AsQueryable();
        }

        /// <summary>
        /// Add Item
        /// </summary>
        [TestMethod]
        public async Task AddCourse()
        {
            var mockSet = new Mock<DbSet<Course>>();

            var mocCourse = new Mock<Course>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(m => m.Courses).Returns(mockSet.Object);

            var mockCourseCollection = new CourseCollection(mockContext.Object);
            var mockUnitOfWork = new UnitOfWork(mockContext.Object);

            await mockCourseCollection.Add(mocCourse.Object);
            await mockUnitOfWork.Complete();

            mockSet.Verify(m => m.Add(It.IsAny<Course>()), Times.Once());

            mockContext.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [TestMethodAttribute]
        public async Task GetAllCourses()
        {
            var mockSet = new Mock<DbSet<Course>>();
            mockSet.As<IQueryable<Course>>().Setup(i => i.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Course>>().Setup(i => i.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Course>>().Setup(i => i.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Course>>().Setup(i => i.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Courses).Returns(mockSet.Object);

            var mockCourseCollection = new CourseCollection(mockContext.Object);
            var Courses = (await mockCourseCollection.GetAll()).ToList();

            Assert.AreEqual(2, Courses.Count());
            Assert.AreEqual("Math101", Courses[0].CourseId);
            Assert.AreEqual("Math 101", Courses[0].Name);
            Assert.AreEqual(100, Courses[1].Level);
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        [TestMethodAttribute]
        public async Task UpdateCourse()
        {
            var mockSet = new Mock<DbSet<Course>>();
            mockSet.As<IQueryable<Course>>().Setup(i => i.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Course>>().Setup(i => i.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Course>>().Setup(i => i.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Course>>().Setup(i => i.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Courses).Returns(mockSet.Object);

            var mockUnitOfWork = new UnitOfWork(mockContext.Object);

            var mockCourseCollection = new CourseCollection(mockContext.Object);
            var Courses = (await mockCourseCollection.GetAll()).ToList();

            var Course = Courses[0];

            Course.Name = "Physic 200";
            Course.Level = 200;
            Course.CourseId = "Physic200";

            await mockUnitOfWork.Complete();

            Assert.AreEqual(2, Courses.Count());
            Assert.AreEqual("Physic 200", Courses[0].Name);
            Assert.AreEqual(200, Courses[0].Level);
            Assert.AreEqual("Physic200", Courses[0].CourseId);
            mockContext.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());
        }
    }
}
