using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class BillingPeriod
{
    public int BillingPeriodId { get; set; }
    [Required]
    public string OrganizationId { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    [Required]
    public DateTime StartDate { get; set; }
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    [Required]
    public DateTime EndDate { get; set; }

}
