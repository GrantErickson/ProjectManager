using Microsoft.EntityFrameworkCore;
using ProjectManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data;
public static class DatabaseSeed
{
    public static void Seed(AppDbContext db)
    {
        if (!db.ApplicationUsers.Any()) InitialSeed(db);
        if (!db.ApplicationUsers.Any(f => f.IsAppAdmin)) AddAdmins(db);
    }

    public static void InitialSeed(AppDbContext db)
    {
        // Users
        var appGrant = new ApplicationUser
        {
            Email = "grant@intellitect.com",
            Name = "Grant Erickson"
        };
        db.ApplicationUsers.Add(appGrant);
        var appPhil = new ApplicationUser
        {
            Email = "phil@intellitect.com",
            Name = "Phil Spokas"
        };
        db.ApplicationUsers.Add(appPhil);

        // Organizations
        var intellitect = new Organization
        {
            Name = "IntelliTect"
        };
        db.Organizations.Add(intellitect);
        var mareli = new Organization
        {
            Name = "MarEli Properties"
        };
        db.Organizations.Add(mareli);

        db.BillingPeriods.Add(new BillingPeriod
        {
            Name = "July 2022",
            StartDate = DateTime.Parse("7/1/2022"),
            EndDate = DateTime.Parse("7/31/2022"),
            Organization = intellitect,
        });
        db.BillingPeriods.Add(new BillingPeriod
        {
            Name = "August 2022",
            StartDate = DateTime.Parse("8/1/2022"),
            EndDate = DateTime.Parse("8/31/2022"),
            Organization = intellitect,
        });
        db.BillingPeriods.Add(new BillingPeriod
        {
            Name = "September 2022",
            StartDate = DateTime.Parse("9/1/2022"),
            EndDate = DateTime.Parse("9/30/2022"),
            Organization = intellitect,
        });
        db.BillingPeriods.Add(new BillingPeriod
        {
            Name = "October 2022",
            StartDate = DateTime.Parse("10/1/2022"),
            EndDate = DateTime.Parse("10/31/2022"),
            Organization = intellitect,
        });
        db.BillingPeriods.Add(new BillingPeriod
        {
            Name = "November 2022",
            StartDate = DateTime.Parse("11/1/2022"),
            EndDate = DateTime.Parse("11/30/2022"),
            Organization = intellitect,
        });
        db.BillingPeriods.Add(new BillingPeriod
        {
            Name = "December 2022",
            StartDate = DateTime.Parse("12/1/2022"),
            EndDate = DateTime.Parse("12/31/2022"),
            Organization = intellitect,
        });

        // Skills
        var cs = new Skill
        {
            Name = "C#"
        };
        db.Skills.Add(cs);
        var python = new Skill
        {
            Name = "Python"
        };
        db.Skills.Add(python);
        var ts = new Skill
        {
            Name = "TypeScript"
        };
        db.Skills.Add(ts);
        var customerManager = new Skill
        {
            Name = "Customer Manager"
        };
        db.Skills.Add(customerManager);

        // Organization Users
        var grant = new OrganizationUser
        {
            Organization = intellitect,
            AppUser = appGrant,
            DefaultRate = 100,
            EmploymentStatus = OrganizationUser.EmploymentStatusEnum.FullTime,
            IsActive = true,
            IsOrganizationAdmin = true,
            Name = "Grant E.",
        };
        db.OrganizationUsers.Add(grant);
        var phil = new OrganizationUser
        {
            Organization = intellitect,
            AppUser = appPhil,
            DefaultRate = 100,
            EmploymentStatus = OrganizationUser.EmploymentStatusEnum.FullTime,
            IsActive = true,
            IsOrganizationAdmin = true,
            Name = "Phil S.",
        };

        // UserSkills
        db.UserSkills.Add(new UserSkill
        {
            Level = 10,
            Skill = customerManager,
            User = phil
        });
        db.UserSkills.Add(new UserSkill
        {
            Level = 7,
            Skill = cs,
            User = phil
        });
        db.UserSkills.Add(new UserSkill
        {
            Level = 4,
            Skill = python,
            User = phil
        });
        db.UserSkills.Add(new UserSkill
        {
            Level = 5,
            Skill = ts,
            User = phil
        });
        db.UserSkills.Add(new UserSkill
        {
            Level = 6,
            Skill = customerManager,
            User = grant
        });
        db.UserSkills.Add(new UserSkill
        {
            Level = 8,
            Skill = cs,
            User = grant
        });
        db.UserSkills.Add(new UserSkill
        {
            Level = 7,
            Skill = ts,
            User = grant
        });

        // Clients
        var intelliWiki = new Client
        {
            Name = "IntelliWiki",
            Organization = intellitect,
        };
        db.Clients.Add(intelliWiki);
        var p66 = new Client
        {
            Name = "Phillips 66",
            Organization = intellitect,
        };
        db.Clients.Add(p66);

        //Projects
        var intelliWikiDev = new Project
        {
            Name = "IntelliWiki Dev",
            Client = intelliWiki,
            IsBillableDefault = false,
            ProjectState = Project.ProjectStateEnum.Active
        };
        db.Projects.Add(intelliWikiDev);
        var intelliWikiSupport = new Project
        {
            Name = "IntelliWiki Support",
            Client = intelliWiki,
            IsBillableDefault = false,
            ProjectState = Project.ProjectStateEnum.Active
        };
        db.Projects.Add(intelliWikiSupport);
        var intelliWikiCustomerDev = new Project
        {
            Name = "IntelliWiki Dev for Customer X",
            Client = intelliWiki,
            IsBillableDefault = true,
            ProjectState = Project.ProjectStateEnum.Active
        };
        db.Projects.Add(intelliWikiCustomerDev);
        var p66Midstream = new Project
        {
            Name = "Midstream",
            Client = p66,
            IsBillableDefault = true,
            ProjectState = Project.ProjectStateEnum.Active
        };
        db.Projects.Add(p66Midstream);
        var p66NewWork = new Project
        {
            Name = "P66 New Project",
            Client = p66,
            IsBillableDefault = true,
            ProjectState = Project.ProjectStateEnum.Potential,
            Probability = 50
        };
        db.Projects.Add(p66Midstream);

        //ProjectNotes
        db.ProjectNotes.Add(new ProjectNote
        {
            Project = p66Midstream,
            Note = "Phil will be managing this project as the customer needs consistent financial feedback.",
        });
        db.ProjectNotes.Add(new ProjectNote
        {
            Project = intelliWikiDev,
            Note = "This is our internal project IntelliWiki.",
        });
        db.ProjectNotes.Add(new ProjectNote
        {
            Project = intelliWikiDev,
            Note = "We have decided to move ahead and add enterprise features as of 6/1/2022.",
        });

        // Assignments
        var grantWiki = new Assignment
        {
            PercentAllocated = 50,
            Project = intelliWikiDev,
            User = grant,
            Role = "Lead Dev",
            Rate = 100,
        };
        db.Assignments.Add(grantWiki);
        var philP66 = new Assignment
        {
            PercentAllocated = 90,
            Project = p66Midstream,
            User = phil,
            Role = "Python PM",
            Rate = 120,
            isLongTerm = true,
        };
        db.Assignments.Add(philP66);
        var philWikiSupport = new Assignment
        {
            PercentAllocated = 90,
            Project = intelliWikiSupport,
            User = phil,
            Role = "PM",
            Rate = 60,
            isLongTerm = true,
        };
        db.Assignments.Add(philWikiSupport);

        // Assignment Skills
        db.AssignmentSkills.Add(new AssignmentSkill
        {
            Assignment = grantWiki,
            Skill = cs,
            Level = 9
        });
        db.AssignmentSkills.Add(new AssignmentSkill
        {
            Assignment = grantWiki,
            Skill = ts,
            Level = 7
        });
        db.AssignmentSkills.Add(new AssignmentSkill
        {
            Assignment = philP66,
            Skill = python,
            Level = 6
        });
        db.AssignmentSkills.Add(new AssignmentSkill
        {
            Assignment = philP66,
            Skill = customerManager,
            Level = 10
        });
        db.AssignmentSkills.Add(new AssignmentSkill
        {
            Assignment = philWikiSupport,
            Skill = customerManager,
            Level = 4
        });

        db.SaveChanges();
    }

    public static void AddAdmins(AppDbContext db)
    {
        db.ApplicationUsers.First(f => f.Email == "grant@intellitect.com").IsAppAdmin = true;
        db.ApplicationUsers.First(f => f.Email == "phil@intellitect.com").IsAppAdmin = true;
        foreach (var orgUser in db.ApplicationUsers.Include(f => f.Organizations).First(f => f.Email == "grant@intellitect.com").Organizations)
        {
            orgUser.IsOrganizationAdmin = true;
        }
        foreach (var orgUser in db.ApplicationUsers.Include(f => f.Organizations).First(f => f.Email == "phil@intellitect.com").Organizations)
        {
            orgUser.IsOrganizationAdmin = true;
        }
        db.SaveChanges();
    }
}
