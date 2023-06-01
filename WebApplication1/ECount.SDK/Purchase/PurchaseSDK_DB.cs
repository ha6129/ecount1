using ECount.CoreBase;
using ECount.CoreBase.LOG;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace ECountSDK
{
	public class PurchaseSDK_DB : IPurchaseSDK
	{
		private ProductSDK_DB product;
		private CustomerSDK_DB customer;
		public ILogger logger = LoggerManager.LoggerFactory(Option.LogType);

		public PurchaseSDK_DB()
		{
			this.product = new ProductSDK_DB();
			this.customer = new CustomerSDK_DB();
		}
		List<Purchase> _purchase = new List<Purchase>();
		public void Callback(SqlDataReader reader)
		{
			while (reader.Read())
			{ // 하나의 row씩 읽는다.
				var _product = new Product();
				var _customer = new Customer();

				var pur = new Purchase();
				pur.Index = (int)reader["ID"];
				_customer.Code = reader["CustCode"] as string;
				_customer.Name = reader["CustName"] as string;
				_product.Code = reader["CODE"] as string;
				_product.Name = reader["NAME"] as string;
				pur.Quantity = (int)reader["QUANTITY"];
				pur.DataTime = (DateTime)reader["DATETIME"];

				pur.Customer = _customer;
				pur.Product = _product;

				_purchase.Add(pur);
			}
		}

		public void Create(Purchase purchase)
		{
			Customer cust = purchase.Customer;
			Product prod = purchase.Product;

			string formattedDatetime = purchase.DataTime.ToString("yyyy-MM-dd HH:mm:ss");
			string sql = $"EXEC PURCHASE_INSERT_HHY '{cust.Code}','{cust.Name}','{prod.Code}','{prod.Name}','{purchase.Quantity}','{formattedDatetime}'";
			DB.CallDB(sql);
			logger.Write<Purchase>(purchase, "생성");
		}

		public void Update(Purchase purchase)
		{
			Customer cust = purchase.Customer;
			Product prod = purchase.Product;
			string formattedDatetime = purchase.DataTime.ToString("yyyy-MM-dd HH:mm:ss");
			string sql = $"EXEC PURCHASE_UPDATE_HHY '{purchase.Index}','{cust.Code}','{cust.Name}','{prod.Code}','{prod.Name}','{purchase.Quantity}','{formattedDatetime}'";
			DB.CallDB(sql);
			logger.Write<Purchase>(purchase, "수정");

		}
		public void Delete(List<Purchase> purchase)
		{
			foreach (var pur in purchase)
			{
				string sql = $"EXEC PURCHASE_DELETE_HHY {pur.Index}";
				DB.CallDB(sql);
				logger.Write<Purchase>(pur, "삭제");
			}
		}
		//구매조회
		public List<Purchase> GetHistory()
		{
			string sql = $"EXEC PURCHASE_SEARCH_HHY";


			DB.CallDB(sql, Callback);
			return _purchase;
		}

		public List<Purchase> GetHistory(string code)
		{
			string sql = $"EXEC PURCHASE_SEARCH_HHY null, '{code}'";

			DB.CallDB(sql, Callback);
			return _purchase;
		}

		public List<Purchase> GetHistoryByCustCode(string code)
		{
			string sql = $"EXEC PURCHASE_SEARCH_HHY '{code}', null";

			DB.CallDB(sql, Callback);
			return _purchase;
		}

		//public List<Purchase> GetHistoryByName(string name)
		//{
		//	throw new NotImplementedException();
		//}

		//public List<Purchase> GetHistoryByType(ProductType type)
		//{
		//	throw new NotImplementedException();
		//}

		//public List<Purchase> GetHistoryByName(string name)
		//{

		//}


		//public List<Purchase> GetHistoryByType(ProductType type)
		//{

		//}
	}
}
