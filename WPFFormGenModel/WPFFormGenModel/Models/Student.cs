using System;
using System.Collections.Generic;

namespace WPFFormGenModel.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? Phone { get; set; }
        public int? Major { get; set; }

        public virtual Major? MajorNavigation { get; set; }
    }
}
