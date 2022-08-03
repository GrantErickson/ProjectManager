using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Data.Models
{
    public class ProjectNote : TrackingBase
    {
        public int ProjectNoteId { get; set; }
        public string Note { get; set; } = null!;
        public string? DocumentUrl { get; set; } = null!;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    }
}