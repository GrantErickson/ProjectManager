using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Organization
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrganizationId { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<OrganizationUser> Users { get; set; } = null!;
    public ICollection<BillingPeriod> BillingPeriods { get; set; } = null!;
    public ICollection<Client> Clients { get; set; } = null!;

}
