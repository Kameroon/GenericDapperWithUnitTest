using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoralesLarios.Data.Dapper;

namespace ML.DataProject
{
    public class DepartmentRepository : DPGenericRepository<Departments>
    {
        public DepartmentRepository(IDbConnection conn, char parameterIdentified = '@') :
            base(conn, parameterIdentified)
        {

        }

    }
}
