using aspnet_core;
using aspnet_core.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace aspnet_core.tests
{
    /// <summary>
    /// InstructorCollectionShould test class 
    /// </summary>
    [TestClass]
    public class InstructorCollectionShould
    {
        

        /// <summary>
        /// Add item
        /// </summary>
        [TestMethod]
        public void AddItem()
        {
            var mockSet = new Mock<DbSet<Instructor>>();

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(m => m.Instructors).Returns(mockSet.Object);

            

            mockSet.Verify(m => m.Add(It.IsAny<Instructor>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}