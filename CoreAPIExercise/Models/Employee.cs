using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CoreAPIExercise.Models
{
    public partial class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Guid JobTitleId { get; set; }
        public Guid DivisionId { get; set; }
    }
}
