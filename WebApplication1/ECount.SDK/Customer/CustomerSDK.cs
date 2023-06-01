using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ECountSDK
{
	//인메모리 클래스
	public class CustomerSDK : ICustomerSDK
	{

		public static List<Customer> _custList = new List<Customer>();

		public CustomerSDK()
		{
			//_custList.Clear();
			//_custList.Add(new Customer { CustCode = "A001", CustName = "이카운트" });
			//_custList.Add(new Customer { CustCode = "A002", CustName = "삼카운트" });
		}

		public void Create(Customer customer)
		{
			_custList.Add(new Customer(customer.Code, customer.Name));
		}

		public void Update(Customer customer)
		{
			Customer cust = _custList.Find(x => x.Code == customer.Code);
			cust.Name = customer.Name;
		}
		public void Delete(List<Customer> customers)
		{
			foreach (var customer in customers)
			{
				Customer cust = _custList.Find(x => x.Code == customer.Code);

				_custList.Remove(cust);
			}
		}
		//전체거래처 가져오기
		public List<Customer> GetList()
		{
			return _custList;
		}
		//특정거래처 가져오기
		public List<Customer> Get(string code)
		{
			return _custList.FindAll(x => x.Code.Contains(code));
		}

		//public List<Customer> GetCustomerByName(string name)
		//{
		//	return _custList.FindAll(x => x.Name.Contains(name));
		//}

	}
}
