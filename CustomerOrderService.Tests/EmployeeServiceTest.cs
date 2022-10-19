using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.Tests
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        [TestCase(15, ExpectedResult =false)]
        [TestCase(65, ExpectedResult = true)]
        [TestCase(35, ExpectedResult = false)]
        [TestCase(75, ExpectedResult = true)]
        public bool GetAge(int age)
        {
            Employee e = new Employee();
            e.EmpId = 12;
            e.EmpName = "Ravi";
            e.Age = age;
            bool ans = e.IsSenior();
            return ans;
        }
        
    }
}
