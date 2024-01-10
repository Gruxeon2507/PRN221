using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WPFFormGenModel.Models
{
    [XmlRoot("Student")]
    public partial class Student
    {   
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; } = null!;
        [XmlElement("Dob")]
        public DateTime? Dob { get; set; }
        [XmlElement("Gemder")]
        public bool? Gender { get; set; }
        [XmlElement("Phone")]
        public string? Phone { get; set; }
        [XmlElement("Major")]
        public int? Major { get; set; }

        public virtual Major? MajorNavigation { get; set; }
    }
}
