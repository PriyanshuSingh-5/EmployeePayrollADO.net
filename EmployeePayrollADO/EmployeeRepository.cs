using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    class EmployeeRepository
    {
        ///Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=LAPTOP-NAVJ6800\SQLEXPRESS;Initial Catalog=Employee_payroll;Integrated Security=True";
        /// Establishing the connection using the Sql
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        ///UC1 Creating a method for checking for the validity of the connection.
        /// </summary>
        public void EnsureDataBaseConnection()
        {
            this.connection.Open();
            using (connection)
            {
                Console.WriteLine("The Connection is created");
            }
            this.connection.Close();
        }
    }
}


