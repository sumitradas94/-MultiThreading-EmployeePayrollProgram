using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeePayrollServiceSQL
{
    public class EmployeePayrollOperations
    {
        List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();

        public void addEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {

                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.addEmployeePayroll(employeeData);
                Console.WriteLine("Employee Added: " + employeeData.EmployeeName);
            });

            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }

        public void addEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailList.Add(emp);
        }

    }
}