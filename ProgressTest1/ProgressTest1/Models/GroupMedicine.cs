using System;
using System.Collections.Generic;

namespace ProgressTest1.Models
{
    public partial class GroupMedicine
    {
        public GroupMedicine()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
