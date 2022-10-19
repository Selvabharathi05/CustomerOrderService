using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomerOrderService.Tests
{
    [TestFixture(CustomerType.Basic)]
    [TestFixture(CustomerType.Premimum, 101)]
   
    
    public class CustomerOrderTest
    {
        CustomerType cType;
        CustomerType cType1;
        Order o = new Order();
        public CustomerOrderTest(CustomerType cType)
        {
            this.cType = cType;
        }

        public CustomerOrderTest(CustomerType cType1,double Amount)
        {
            this.cType1 = cType1;
            o.Amount = Amount;  
        }

        [TestCase]

        public void TestMethod()
        {
            Assert.IsTrue(cType == CustomerType.Basic);
            //Assert.IsTrue(cType == CustomerType.Basic);
        }

        [TestCase]

        public void TestMethod1()
        {
            Assert.IsTrue(cType == CustomerType.Premimum && o.Amount > 0);
            //Assert.IsTrue(cType == CustomerType.Basic);
        }

        [TestCase]
        public void When_Premimum_10percent()
        {
           Customer c = new Customer();
            c.CustId = "101";
            c.CustName = "Selva";
            c.CustomerType = CustomerType.Premimum;
           Order order = new Order();
            order.OrderId = 1;
            order.ProductId = 2;
            order.Qty = 5;
            order.Amount = 100;

            CustomerOrder co = new CustomerOrder();
            co.Discount(c, order);
            Assert.AreEqual(order.Amount, 90);
        }



        [TestCase]
        public void When_Gold_20percent()
        {
            Customer c = new Customer();
            c.CustId = "101";
            c.CustName = "Selva";
            c.CustomerType = CustomerType.Gold;
            Order order = new Order();
            order.OrderId = 1;
            order.ProductId = 2;
            order.Qty = 5;
            order.Amount = 100;

            CustomerOrder co = new CustomerOrder();
            co.Discount(c, order);
            Assert.AreEqual(order.Amount, 80);
        }

        [TestCase]
        public void FetchList()
        {
            CustomerOrder customerOrder = new CustomerOrder();
            Customer c1 = new Customer();

            customerOrder.GetCustomersList(c1);
            List<Customer> custList1 = new List<Customer>();
            custList1.Add(new Customer() { CustId = "ab", CustName = "Selva" });
            custList1.Add(new Customer() { CustId = "cd", CustName = "Bharathi" });
            Assert.AreEqual(custList1, c1.CustList);
        }
    }
}
