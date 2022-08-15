namespace ProjectManager.Data.Tests
{
    [TestClass]
    public class AssignmentTests : DatabaseTestBase
    {
        [TestMethod]
        public void GetUsersWithSkills()
        {
            using var db = new AppDbContext(Options);
            // Get the assignment: cs/ts
            var assignment1 = db.Assignments
                .FirstOrDefault(f => f.Role == "Lead Dev");
            Assert.IsNotNull(assignment1);

            var result1 = assignment1.GetUsersWithSkills(db);
            Assert.AreEqual(result1.Count(), 2);

            // Get the assignment: python
            var assignment2 = db.Assignments
                .FirstOrDefault(f => f.Role == "Python PM");
            Assert.IsNotNull(assignment2);

            var result2 = assignment2.GetUsersWithSkills(db);
            Assert.AreEqual(result2.Count(), 1);
        }

    }
}