using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public int OrganizationId { get; set; }// = null!;
    public Organization Organization { get; set; } = null!;
    public string? AgreementUrl { get; set; }
    public string? PrimaryContact { get; set; }
    public string? BillingContact { get; set; }

    public ICollection<Project> Projects { get; set; } = null!;

    
}
