using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataProject
{
    public class ConnectionSettingsSettings
    {
        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"c:\\users\\ck8319\\documents\\visual studio 2017\\Projects\\ML.DataProject\\ML.DataProject\\TestDB.mdf\";Integrated Security = True";

        public static string GetConnectionString()
        {
            string appPath = Environment.CurrentDirectory;

            var result = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{appPath}\\TestDB.mdf\";Integrated Security = True";

            return result;
        }

    }
}
