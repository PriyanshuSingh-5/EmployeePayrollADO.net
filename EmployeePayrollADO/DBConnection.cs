using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    class DBConnection
    {
       
        public SqlConnection GetConnection()
        {

            //Specifying the connection string from the sql server connection
            string connectionString = @"Data Source=DESKTOP-4849HJR;Initial Catalog=payroll_service;Integrated Security=True;User ID=dheermeena;Password=Dheer@1998";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
