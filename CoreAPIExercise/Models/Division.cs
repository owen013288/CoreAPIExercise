using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CoreAPIExercise.Models
{
    public partial class Division
    {
        public Division()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid DivisionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
