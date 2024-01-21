using System;
using System.Collections.Generic;

namespace ProgressTest1.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
