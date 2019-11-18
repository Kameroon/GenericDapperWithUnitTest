using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Data.Dapper;

namespace ML.DataProject
{
    public class EmployeesRepository : DPGenericRepository<Employees>
    {
        public EmployeesRepository(IDbConnection conn, char parameterIdentified = '@') :
            base(conn, parameterIdentified)
        {
        }
    }
}
