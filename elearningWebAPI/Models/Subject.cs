using System;
using System.Collections.Generic;

namespace elearningWebAPI.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Subtemas = new HashSet<Subtema>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDesc { get; set; }
        public bool? IsActive { get; set; }
        public int? Kelas { get; set; }
        public string UrlEbook { get; set; }

        public virtual ICollection<Subtema> Subtemas { get; set; }
    }
}
