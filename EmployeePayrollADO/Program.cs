using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Employee Payroll Services Using ADO.NET");
            //Creating a instance object of EmployeeRepository class.
            EmployeeRepository repository = new EmployeeRepository();

            // UC1 Ensuring the database connection using the sql connection string
            //  repository.EnsureDataBaseConnection();
            //repository.GetAllEmployeeData();
            //repository.AddEmployee();

            Inputdata();


            Console.ReadLine();
        }
        public static void Inputdata()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Rahul";
            model.Address = "Jabalpur";
            model.BasicPay = 70000;
            model.Deductions = 500;
            model.Department = "Testor";
            model.Gender = "M";
            model.PhoneNumber = 9567986354;
            model.NetPay = 73000;
            model.Tax = 1000;
            model.StartDate = DateTime.Now;
            model.TaxablePay = 500;

            repository.AddEmployee(model);

            //Console.WriteLine(repository.UpdateSalaryIntoDatabase("Priyanshu", 50000) ? "Update done successfully " : "Update Failed");
            //repository.GetEmployeesFromForDateRange("2018 - 05 - 03");
            repository.FindGroupedByGenderData("M");
            Console.ReadKey();
        }
    }
}
