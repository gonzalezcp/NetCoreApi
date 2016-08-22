using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using DataModel;

namespace EFTestService.Tests
{
    [TestClass]
    public class NonQueryTests
    {
        [TestMethod]
        public void CreateBlog_saves_a_blog_via_context()
        {
            var mockSet = new Mock<DbSet<Blog>>();
            var mockContext = new Mock<BloggingEntities>();
            mockContext.Setup(m => m.Blog).Returns(mockSet.Object);

            var service = new BlogService(mockContext.Object);
            service.AddBlog("http://blogs.msdn.com/adonet");
            mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
