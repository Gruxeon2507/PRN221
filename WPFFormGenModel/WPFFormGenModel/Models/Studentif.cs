using System;
using System.Collections.Generic;

namespace WPFFormGenModel.Models
{
    public partial class Studentif
    {
        public string Rollnumber { get; set; } = null!;
        public string? StudentName { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Address { get; set; }
    }
}
