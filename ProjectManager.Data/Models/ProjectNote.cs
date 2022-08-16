using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectManager.Data.Models
{
    public class ProjectNote : TrackingBase
    {
        public int ProjectNoteId { get; set; }
        [Required]
        public string Note { get; set; } = null!;
        public string? DocumentUrl { get; set; } = null!;
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    }
}