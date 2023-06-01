using ECount.CoreBase;
using ECount.CoreBase.LOG;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace ECountSDK
{
	public class SaleSDK_DB : ISaleSDK
	{
		private ProductSDK_DB product;
		private CustomerSDK_DB customer;
		public ILogger logger = LoggerManager.LoggerFactory(Option.LogType);
		public SaleSDK_DB()
		{
			this.product = new ProductSDK_DB();
			this.customer = new CustomerSDK_DB();
		}
		List<Sale> _sale = new List<Sale>();
		public void Callback(SqlDataReader reader)
		{
			while (reader.Read())
			{ // 하나의 row씩 읽는다.
				var _product = new Product();
				var _customer = new Customer();

				var sal = new Sale();
				sal.Index = (int)reader["ID"];
				_customer.Code = reader["CustCode"] as string;
				_customer.Name = reader["CustName"] as string;
				_product.Code = reader["CODE"] as string;
				_product.Name = reader["NAME"] as string;
				sal.Quantity = (int)reader["QUANTITY"];
				sal.DataTime = (DateTime)reader["DATETIME"];

				sal.Customer = _customer;
				sal.Product = _product;

				_sale.Add(sal);
			}
		}

		public void Create(Sale sale)
		{
			Product prod = sale.Product;
			Customer cust = sale.Customer;

			string formattedDatetime = sale.DataTime.ToString("yyyy-MM-dd HH:mm:ss");
			string sql = $"EXEC SALE_INSERT_HHY '{cust.Code}','{cust.Name}','{prod.Code}','{prod.Name}','{sale.Quantity}','{formattedDatetime}'";
			DB.CallDB(sql);
			logger.Write<Sale>(sale, "생성");
		}
		public void Update(Sale sale)
		{

			Product prod = sale.Product;
			Customer cust = sale.Customer;
			string formattedDatetime = sale.DataTime.ToString("yyyy-MM-dd HH:mm:ss");
				string sql = $"EXEC SALE_UPDATE_HHY '{sale.Index}','{cust.Code}','{cust.Name}','{prod.Code}','{prod.Name}','{sale.Quantity}','{formattedDatetime}'";
				DB.CallDB(sql);
				logger.Write<Sale>(sale, "수정");
			
		}
		public void Delete(List<Sale> sale)
		{
			foreach (var sal in sale)
			{
				string sql = $"EXEC SALE_DELETE_HHY {sal.Index}";
				DB.CallDB(sql);
				logger.Write<Sale>(sal, "삭제");
			}
		}
		//판매조회
		public List<Sale> GetHistory()
		{
			string sql = $"EXEC SALE_SEARCH_HHY";

			DB.CallDB(sql, Callback);
			return _sale;
		}

		public List<Sale> GetHistory(string code)
		{
			string sql = $"EXEC SALE_SEARCH_HHY null, '{code}'";

			DB.CallDB(sql, Callback);
			return _sale;
		}
		public List<Sale> GetHistoryByCustCode(string code)
		{
			string sql = $"EXEC SALE_SEARCH_HHY '{code}', null";

			DB.CallDB(sql, Callback);
			return _sale;
		}

		public List<Sale> GetHistoryByName(string name)
		{
			throw new NotImplementedException();
		}

		public List<Sale> GetHistoryByType(InfoType type)
		{
			throw new NotImplementedException();
		}

		//public List<Sale> GetHistoryByName(string name)
		//{
		//	return _sales.FindAll(x => x.Product.Name == name);
		//}


		//public List<Sale> GetHistoryByType(ProductType type)
		//{
		//	return _sales.FindAll(x => x.Product.Type == type);
		//}
	}
}
