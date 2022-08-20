using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Tag
{
    public int TagId { get; set; }
    public string Name { get; set; } = null!;
    public string? Color { get; set; }

    [ManyToMany("Projects")]
    public ICollection<ProjectTag> TagProjects { get; set; } = null!;
}
