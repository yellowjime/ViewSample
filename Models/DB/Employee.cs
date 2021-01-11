using System;
using System.Collections.Generic;

#nullable disable

namespace ViewSample.Models.DB
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
    }
}
