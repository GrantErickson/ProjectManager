using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Client
{
    public int ClientId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string OrganizationId { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
    public string? AgreementUrl { get; set; }
    public string? PrimaryContact { get; set; }
    public string? BillingContact { get; set; }
    public string? ContractUrl { get; set; }
    
    public ICollection<Project> Projects { get; set; } = null!;

    
}
