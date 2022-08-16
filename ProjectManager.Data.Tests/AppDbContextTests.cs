namespace ProjectManager.Data.Tests
{
    [TestClass]
    public class AppDbContextTests: DatabaseTestBase
    {
        [TestMethod]
        public void ContextTest()
        {
            using var context = new AppDbContext(Options);
            Assert.IsTrue(context.ApplicationUsers.Count() > 0);
        }
    }
}