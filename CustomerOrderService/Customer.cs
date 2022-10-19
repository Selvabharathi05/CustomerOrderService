using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CustomerOrderService
{
	public enum CustomerType
	{
		Basic,Premimum,Gold
	}
    public class Customer
    {
		public string CustId { get; set; }

		public string CustName { get; set; }

		public CustomerType CustomerType { get; set; }

		public List<Customer> CustList { get; set; }

	}

	public class Order
	{
		public int OrderId { get; set; }

		public int ProductId { get; set; }

		public int Qty { get; set; }

		public double Amount { get; set; }
	}

	public class CustomerOrder
	{
		

		public void Discount(Customer c ,Order o)
		{
			if (c.CustomerType == CustomerType.Premimum)
			{
				o.Amount = o.Amount - (o.Amount * 10 / 100);
			}
			else if(c.CustomerType == CustomerType.Gold)
			{
                o.Amount = o.Amount - (o.Amount * 20 / 100);
            }
		}

		public void GetCustomersList(Customer c1)
		{
			SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["nwndCnStr"].ConnectionString);
			cn.Open();
			
            SqlCommand cmd = new SqlCommand("select * from Customers",cn);
			List<Customer> CList = new List<Customer>();
			SqlDataReader dr = cmd.ExecuteReader();
       
            while (dr.Read())
			{
                Customer cust = new Customer();
				cust.CustName = dr["Name"].ToString();
				cust.CustId = dr[0].ToString();

			}
			cn.Open();
			c1.CustList=CList;	
        }
	}
}
