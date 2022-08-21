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
    public IEnumerable<ProjectInfo> GetProjects(string? search = null)
    {
        var projects = Db.Projects
            .Include(f => f.Assignments.Where(f => f.IsPublic))
                .ThenInclude(f => f.Skills)
                    .ThenInclude(f => f.Skill)
            .Include(f => f.Assignments.Where(f => f.IsPublic))
                .ThenInclude(f => f.User)
            .Include(f => f.Client)
            .Include(f => f.Lead)
            .Where(f => f.IsPublic);
        if (!string.IsNullOrEmpty(search))
        {
            projects = projects.Where(f =>
                f.Client.Name.StartsWith(search) ||
                f.Name.Contains(search) ||
                f.Assignments.Any(a => a.Role.Contains(search) && a.IsPublic) ||
                f.Assignments.Any(a => a.User!=null && a.User.Name.Contains(search) && a.IsPublic) ||
                f.Assignments.Any(a => a.Skills.Any(g => g.Skill.Name.StartsWith(search)) && a.IsPublic) ||
                (f.Lead != null && f.Lead.Name.StartsWith(search))
            );
        }

        return projects.Select(f => new ProjectInfo(f)).ToList();
    }

    public class ProjectInfo
    {
        public string Name { get; set; }
        public IEnumerable<AssignmentInfo> Assignments { get; }
        public string Client { get; }
        public Project.ProjectStateEnum State { get; }
        public string? Lead { get; }
        public ProjectInfo(Project project)
        {
            Name = project.Name;
            Client = project.Client.Name;
            State = project.ProjectState;
            Lead = project.Lead?.Name;
            Assignments = project.Assignments.Select(a => new AssignmentInfo(a)).ToList();
        }
    }

    public class AssignmentInfo
    {
        public string Name { get; }
        public decimal? PercentAllocated { get; }
        public IEnumerable<SkillInfo> Skills { get; }
        public bool IsLongTerm { get; }
        public Assignment.AssignmentStateEnum AssignmentState { get; }
        public string? User { get; }

        public AssignmentInfo(Assignment assignment)
        {
            Name = assignment.Role;
            PercentAllocated = assignment.PercentAllocated;
            Skills = assignment.Skills.Select(s => new SkillInfo(s)).ToList();
            IsLongTerm = assignment.isLongTerm;
            AssignmentState = assignment.AssignmentState;
            User = assignment.User?.Name;
        }
    }

    public class SkillInfo
    {
        public string Name { get; }
        public int? Level { get; }
        public string? Description { get; }

        public SkillInfo(AssignmentSkill skill)
        {
            Name = skill.Skill.Name;
            Level = skill.Level;
            Description = skill.Skill.Description;
        }
    }


}
