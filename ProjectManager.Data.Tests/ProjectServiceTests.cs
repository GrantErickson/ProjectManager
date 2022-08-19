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
        
        [TestMethod]
        public void GetProjectsWithSearch1()
        {
            using var db = new AppDbContext(Options);
            var service = new ProjectService(db);
            var result = service.GetProjects("Intelli");

            Assert.AreEqual(result.Count(), 3);
            Assert.AreEqual(result.First(f => f.Name == "IntelliWiki Dev").Assignments.Count(), 1);
            Assert.AreEqual(result.First(f => f.Name == "IntelliWiki Dev").Assignments.First().Skills.Count(), 2);

        }


        [TestMethod]
        public void GetProjectsWithSearch2()
        {
            using var db = new AppDbContext(Options);
            var service = new ProjectService(db);
            var result = service.GetProjects("Phil");

            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First().Assignments.Count(), 1);
            Assert.AreEqual(result.First().Assignments.First().Skills.Count(), 2);

        }

        [TestMethod]
        public void GetProjectsWithSearch3()
        {
            using var db = new AppDbContext(Options);
            var service = new ProjectService(db);
            var result = service.GetProjects("C#");

            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First().Assignments.Count(), 1);
            Assert.AreEqual(result.First().Assignments.First().Skills.Count(), 2);

        }
    }
}