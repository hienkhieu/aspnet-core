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
    /// InstructorCollectionShould
    /// </summary>
    [TestClass]
    public class InstructorCollectionShould
    {
        private IQueryable<Instructor> data;

        /// <summary>
        /// Constructor
        /// </summary>
        public InstructorCollectionShould()
        {
            data = new List<Instructor>{
                new Instructor{ InstructorId = 1, Firstname = "Hien", Lastname = "Khieu", Age = 43},
                new Instructor{ InstructorId = 2, Firstname = "Bao", Lastname = "Vu", Age = 37}
            }.AsQueryable();
        }

        /// <summary>
        /// Add Item
        /// </summary>
        [TestMethod]
        public async Task AddInstructor()
        {
            var mockSet = new Mock<DbSet<Instructor>>();

            var mocInstructor = new Mock<Instructor>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(m => m.Instructors).Returns(mockSet.Object);

            var mockInstructorCollection = new InstructorCollection(mockContext.Object);
            var mockUnitOfWork = new UnitOfWork(mockContext.Object);

            await mockInstructorCollection.Add(mocInstructor.Object);
            await mockUnitOfWork.Complete();

            mockSet.Verify(m => m.Add(It.IsAny<Instructor>()), Times.Once());

            mockContext.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [TestMethodAttribute]
        public async Task GetAllInstructors()
        {
            var mockSet = new Mock<DbSet<Instructor>>();
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Instructors).Returns(mockSet.Object);

            var mockInstructorCollection = new InstructorCollection(mockContext.Object);
            var instructors = (await mockInstructorCollection.GetAll()).ToList();

            Assert.AreEqual(2, instructors.Count());
            Assert.AreEqual("Bao", instructors[1].Firstname);
            Assert.AreEqual("Vu", instructors[1].Lastname);
            Assert.AreEqual(43, instructors[0].Age);
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        [TestMethodAttribute]
        public async Task UpdateInstructor()
        {
            var mockSet = new Mock<DbSet<Instructor>>();
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Instructor>>().Setup(i => i.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(c => c.Instructors).Returns(mockSet.Object);

            var mockUnitOfWork = new UnitOfWork(mockContext.Object);

            var mockInstructorCollection = new InstructorCollection(mockContext.Object);
            var instructors = (await mockInstructorCollection.GetAll()).ToList();

            var instructor = instructors[0];

            instructor.Firstname = "Elyse";
            instructor.Age = 7;

            await mockUnitOfWork.Complete();

            Assert.AreEqual(2, instructors.Count());
            Assert.AreEqual("Elyse", instructors[0].Firstname);
            Assert.AreEqual("Khieu", instructors[0].Lastname);
            Assert.AreEqual(7, instructors[0].Age);
            mockContext.Verify(m => m.SaveChangesAsync(default(CancellationToken)), Times.Once());
        }
    }
}
