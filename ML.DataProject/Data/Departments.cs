using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataProject
{
    [Serializable]
    public class Departments
    {
        public int    DepartmentID { get; set; }
        public string Name         { get; set; }
        public string Comments     { get; set; }
    }
}
