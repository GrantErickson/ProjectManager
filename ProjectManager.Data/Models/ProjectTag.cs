using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class ProjectTag
{
    public int ProjectTagId { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public int TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}
