using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Organization
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string OrganizationId { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;

    public ICollection<User> Users { get; set; } = null!;
    public ICollection<BillingPeriod> BillingPeriods { get; set; } = null!;
    public ICollection<Client> Clients { get; set; } = null!;

}
