using System;
using System.Data.SqlClient;
using System.Data;
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

        SqlConnection connection1 = new SqlConnection(connectionString);
        //ReInitiallizing the connection using the sql for update employee method.
        SqlConnection connection2 = new SqlConnection(connectionString);



        ///UC1 Creating a method for checking for the validity of the connection.

        public void EnsureDataBaseConnection()
        {
            /// Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            using (connection)
            {
                Console.WriteLine("The Connection is created");
            }
            connection.Close();
        }

        /// UC2 Ability for Employee Payroll Service to retrieve the Employee Payroll from the Database

        public void GetAllEmployeeData()
        {
            //Creating Employee model class object
            EmployeeModel employee = new EmployeeModel();
            try
            {
                using (connection1)
                {
                    //Query to get all the data from table.
                    string query = @"select * from dbo.Employee_Data";
                    //Opening the connection to the statrt mapping.
                    this.connection1.Open();
                    //Implementing the command on the connection fetched database table.
                    SqlCommand command = new SqlCommand(query, connection1);
                    //Executing the Sql datareaeder to fetch the all records.
                    SqlDataReader dataReader = command.ExecuteReader();
                    //Checking datareader has rows or not.
                    if (dataReader.HasRows)
                    {
                        //using while loop for read multiple rows.
                        // Mapping the data to the employee model class object.
                        while (dataReader.Read())
                        {
                            employee.EmployeeId = dataReader.GetInt32(0);
                            employee.EmployeeName = dataReader.GetString(1);
                            employee.BasicPay = dataReader.GetDouble(2);
                            employee.StartDate = dataReader.GetDateTime(3);
                            employee.Gender = dataReader.GetString(4);
                            employee.PhoneNumber = dataReader.GetInt64(5);
                            employee.Department = dataReader.GetString(6);
                            employee.Address = dataReader.GetString(7);
                            employee.Deductions = dataReader.GetDouble(8);
                            employee.TaxablePay = dataReader.GetDouble(9);
                            employee.Tax = dataReader.GetDouble(10);
                            employee.NetPay = dataReader.GetDouble(11);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employee.EmployeeId, employee.EmployeeName,
                                employee.Gender, employee.Address, employee.BasicPay, employee.StartDate, employee.PhoneNumber, employee.Address,
                                employee.Department, employee.Deductions, employee.TaxablePay, employee.Tax, employee.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("no data found ");
                    }
                    dataReader.Close();
                }
            }
            /// Catching the null record exception
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //Always ensuring the closing of the connection
            finally
            {
                this.connection1.Close();
            }

        }
        
        /// Adding Employee To Database
       
        public void AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    //Creating a stored Procedure for adding employees into database
                    SqlCommand command = new SqlCommand("dbo.Employee_Daata", this.connection);
                    //Command type is set as stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Adding values from employeemodel to stored procedure using disconnected architecture
                    //connected architecture will only read the data
                    command.Parameters.AddWithValue("@EmpName", model.EmployeeName);
                    command.Parameters.AddWithValue("@basic_Pay", model.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@gender", model.Gender);
                    command.Parameters.AddWithValue("@phoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@department", model.Department);
                    command.Parameters.AddWithValue("@address", model.Address);
                    command.Parameters.AddWithValue("@deductions", model.Deductions);
                    command.Parameters.AddWithValue("@taxable_pay", model.TaxablePay);
                    command.Parameters.AddWithValue("@income_tax", model.Tax);
                    command.Parameters.AddWithValue("@net_pay", model.NetPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        /// UC3 Updates the given empname with given salary into database.
        /// </summary>
        /// <param name="empName"></param>
        /// <param name="basicPay"></param>
        /// <returns></returns>
        public bool UpdateSalaryIntoDatabase(string empName, double basicPay)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = @"update dbo.employee_payroll set basic_pay=@p1 where EmpName=@p2";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@p1", basicPay);
                    command.Parameters.AddWithValue("@p2", empName);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


