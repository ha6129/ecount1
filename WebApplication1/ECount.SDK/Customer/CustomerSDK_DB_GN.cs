using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ECount.CoreBase;

namespace ECountSDK
{
	public class CustomerSDK_DB2 : CommonDBSDK
	{
		//2. DB
		public void Create(string sql)
		{

			//string sql = SQL.Customer.Create(customer.Code, customer.Name);
			DB.CallDB(sql);
		}

		public void Update(string sql)
		{
			//foreach (var cust in customers)
			//{
			//	string sql = $"EXEC UPDATE_CUSTOMER_LJK '{cust.Code}', '{cust.Name}'";
			DB.CallDB(sql);
			//}
		}
		public void Delete(string sql)
		{
			//foreach (var cust in customers)
			//{
			//	string sql = $"EXEC DELETE_CUSTOMER_LJK '{cust.Code}', '{cust.Name}'";
			DB.CallDB(sql);
			//}
		}
		//전체거래처 가져오기
		//public List<Customer> GetList()
		//{
			//string sql = $"EXEC SEARCH_CUSTOMER_LJK";
			//var _customer = new List<Customer>();

			//void Callback(SqlDataReader reader)
			//{
			//	while (reader.Read())
			//	{ // 하나의 row씩 읽는다.
			//		var cust = new Customer();
			//		cust.Code = reader["CustCode"] as string;
			//		cust.Name = reader["CustName"] as string;

			//		_customer.Add(cust);
			//	}
			//}
			//DB.CallDB(sql, Callback);
			//return _customer;
		//}
		//특정거래처 가져오기
		//public List<Customer> Get(string code) // 코드가 일치하는건 하나밖에없다고 판단하고 customer형으로 만듬..ㅋ
		//{
		//	string sql = $"EXEC SEARCH_CUSTOMER_LJK '{code}'";
		//	List<Customer> _customer = new List<Customer>();

		//	void Callback(SqlDataReader reader)
		//	{
		//			while (reader.Read())
		//			{ // 하나의 row씩 읽는다.
		//				var cust = new Customer();
		//				cust.Code = reader["CustCode"] as string;
		//				cust.Name = reader["CustName"] as string;

		//			_customer.Add(cust);
		//			}
		//	}
		//	DB.CallDB(sql, Callback);
		//	return _customer;
		//}


	}
}

