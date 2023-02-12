using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollUsingThread;
using System.Collections.Generic;
using System;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10Employee_WhenAddedToList_ShouldMaatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeName: "Viraj", PhoneNumber: "9999999999", Address: "Panvel", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Panvel", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 2, EmployeeName: "Vaibhav", PhoneNumber: "9999999999", Address: "Calgary", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Calgary", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 3, EmployeeName: "Varad", PhoneNumber: "9999999999", Address: "Alibag", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Alibag", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 4, EmployeeName: "Mayuri", PhoneNumber: "9999999999", Address: "Sagaon", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Sagaon", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 5, EmployeeName: "Mitali", PhoneNumber: "9999999999", Address: "Karjat", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Karjat", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 6, EmployeeName: "Ram", PhoneNumber: "9999999999", Address: "Neral", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Neral", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 7, EmployeeName: "Shyam", PhoneNumber: "9999999999", Address: "Uran", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Uran", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 8, EmployeeName: "Raju", PhoneNumber: "9999999999", Address: "Shelu", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Shelu", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 9, EmployeeName: "Babu", PhoneNumber: "9999999999", Address: "Pali", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Pali", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 10, EmployeeName: "Pratik", PhoneNumber: "9999999999", Address: "Mahad", Department: "Engineer", Gender: 'M', BasicPay: 10000, Deductions: 200, TaxablePay: 2000, Tax: 1000, NetPay: 6800, City: "Mahad", Country: "India"));

            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            DateTime startDateTime = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayroll(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - startDateTime));

            DateTime startDateTimeThread = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayrollWithThread(employeeDetails);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with Thread: " + (stopDateTimeThread - startDateTimeThread));


        }
    }
}