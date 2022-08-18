using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using ProjectManager.Data.Models;

namespace ProjectManager.Data.Services;

[Coalesce, Service]
public class ProjectService
{
    public AppDbContext Db;

    public ProjectService(AppDbContext db)
    {
        Db = db;
    }

    [Coalesce]
    public IEnumerable<ProjectInfo> GetProjects()
    {
        var projects = Db.Projects
            .Where(f => f.IsPublic)
            .Include(f => f.Assignments.Where(f => f.IsPublic))
                .ThenInclude(f => f.Skills)
                    .ThenInclude(f => f.Skill)
            .Include(f => f.Client)
            .Select(f => new ProjectInfo(f));

        return projects;
    }

    public class ProjectInfo
    {
        public string Name { get; set; }
        public IEnumerable<AssignmentInfo> Assignments { get; }
        public string Client { get; }
        public Project.ProjectStateEnum State { get; }
        
        public ProjectInfo(Project project)
        {
            Name = project.Name;
            Client = project.Client.Name;
            State = project.ProjectState;
            Assignments = project.Assignments.Select(a => new AssignmentInfo(a));
        }
    }

    public class AssignmentInfo
    {
        public string Name { get; }
        public decimal? PercentAllocated { get; }
        public IEnumerable<SkillInfo> Skills { get; }
        public bool IsLongTerm { get; }

        public AssignmentInfo(Assignment assignment)
        {
            Name = assignment.Role;
            PercentAllocated = assignment.PercentAllocated;
            Skills = assignment.Skills.Select(s => new SkillInfo(s));
            IsLongTerm = assignment.isLongTerm;
        }
    }

    public class SkillInfo
    {
        public string Name { get; }
        public int? Level { get; }

        public SkillInfo(AssignmentSkill skill)
        {
            Name = skill.Skill.Name;
            Level = skill.Level;
        }
    }


}
