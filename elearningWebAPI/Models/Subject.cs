using System;
using System.Collections.Generic;

namespace elearningWebAPI.Models
{
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDesc { get; set; }
        public bool? IsActive { get; set; }
    }
}
