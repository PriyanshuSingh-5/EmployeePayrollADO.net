using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollADO;
using System;

namespace EmpRollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       
            /// UC 4 Given the update salary value check if the database got updated.
            /// </summary>
           
            public void GivenUpdateSalaryValue_CheckIfTheDatabaseGotUpdated()
            {
                //Arrange
                string empName = "Priyanshu";
                double basicPay = 60000;
                EmployeeRepository repository = new EmployeeRepository();
                EmployeeModel empModel = new EmployeeModel();
                //Act
                repository.UpdateSalaryIntoDatabase(empName, basicPay);
                double expectedPay = repository.UpdatedSalaryFromDatabase(empName);
                //Assert
                Assert.AreEqual(basicPay, expectedPay);
            }
     }
}

