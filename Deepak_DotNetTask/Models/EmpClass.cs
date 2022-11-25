using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deepak_DotNetTask.Models
{
    public class EmpClass
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public Nullable<System.DateTime> Doj { get; set; }
        public string Department { get; set; }
        public string ReportTo { get; set; }
        public Nullable<int> ContactNo { get; set; }
        public Nullable<System.DateTime> ResignedDate { get; set; }
    }
}