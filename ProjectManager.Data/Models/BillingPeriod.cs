using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class BillingPeriod
{
    public int BillingPeriodId { get; set; }
    public string OrganizationId { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
    public string Name { get; set; } = null!;
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    public DateTime StartDate { get; set; }
    [DateType(DateTypeAttribute.DateTypes.DateOnly)]
    public DateTime EndDate { get; set; }

}
