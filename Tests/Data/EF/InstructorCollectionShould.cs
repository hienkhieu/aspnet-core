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
        /// <summary>
        /// Add Item
        /// </summary>
        [TestMethod]
        public async Task AddItem()
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
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}