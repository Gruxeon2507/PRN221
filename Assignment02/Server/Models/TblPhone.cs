﻿using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class TblPhone
    {
        public int Id { get; set; }
        public string? Branch { get; set; }
        public string? Name { get; set; }
        public DateTime? DateofManufacture { get; set; }
        public bool? StopManufacture { get; set; }
    }
}
