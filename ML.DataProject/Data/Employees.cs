using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataProject
{
    [Serializable]

    public class Employees
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public int Age { get; set; }
        public decimal Incomes { get; set; }
        public int DepartmentID { get; set; }
        public string Comments { get; set; }
    }





}
