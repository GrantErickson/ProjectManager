using ProjectManager.Data.Services;

namespace ProjectManager.Data.Tests
{
    [TestClass]
    public class ProjectServiceTests : DatabaseTestBase
    {
        [TestMethod]
        public void GetProjects()
        {
            using var db = new AppDbContext(Options);
            var service = new ProjectService(db);
            var result = service.GetProjects();

            Assert.AreEqual(result.Count(), 4);
            Assert.AreEqual(result.First(f => f.Name == "IntelliWiki Dev").Assignments.Count(), 1);
            Assert.AreEqual(result.First(f => f.Name == "IntelliWiki Dev").Assignments.First().Skills.Count(), 2);

        }

    }
}