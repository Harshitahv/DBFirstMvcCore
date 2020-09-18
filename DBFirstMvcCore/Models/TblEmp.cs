using System;
using System.Collections.Generic;

namespace DBFirstMvcCore.Models
{
    public partial class TblEmp
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string ContactNum { get; set; }
    }
}
