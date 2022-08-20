using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Models;
public class Contract
{
    public enum ContractStateEnum
    {
        Unknown = 0,
        Draft = 1,
        SentForSignature = 2,
        Active = 3,
        Cancelled = 4,
        Complete = 5,
    }


    public int ContractId { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? ContractUrl { get; set; }
    public decimal? Amount { get; set; }
    public ContractStateEnum State { get; set; } = ContractStateEnum.Unknown;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? UnusedAmount { get; set; }
    public bool HasMustNotExceed { get; set; }
    public string? Notes { get; set; }
}
