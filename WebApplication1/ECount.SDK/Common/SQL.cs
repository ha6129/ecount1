using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public class SQL
	{
		public class Product
		{
			public static string Create(string code, string name, InfoType type)
			{
				return $"EXEC PRODUCT_INSERT_HHY '{code}', '{name}', '{type}'";
			}

			public static string Update(string code, string name, InfoType? type)
			{
				return $"EXEC PRODUCT_UPDATE_HHY '{code}', '{name}', '{type}'";
			}

			public static string Delete(string code, string name, InfoType? type)
			{
				return $"EXEC PRODUCT_DELETE_HHY '{code}'";
			}

			public static string GetList()
			{
				return $"EXEC PRODUCT_SEARCH_HHY";
			}

			public static string Get(string code)
			{
				return $"EXEC PRODUCT_SEARCH_HHY '{code}'";
			}

			public static string GetByType(InfoType type)
			{
				return $"EXEC PRODUCT_SEARCH_HHY @TYPE = '{type}'";
			}
		}

		public class Customer
		{
			public static string Create(string code, string name)
			{
				return $"EXEC CUSTOMER_INSERT_HHY '{code}', '{name}'";
			}

			public static string Update(string code, string name)
			{
				return $"EXEC CUSTOMER_UPDATE_HHY '{code}', '{name}'"; ;
			}

			public static string Delete(string code, string name)
			{
				return $"EXEC CUSTOMER_DELETE_HHY  '{code}', '{name}'";
			}

			public static string GetList()
			{
				return $"EXEC CUSTOMER_SEARCH_HHY";
			}

			public static string Get(string code)
			{
				return $"EXEC CUSTOMER_SEARCH_HHY '{code}'";
			}
		}

		//	public class Purchase
		//	{
		//		public static string Create(List<Customer> cust, List<Product> prod, int? quantity, string formattedDatetime)
		//		{
		//			return $"EXEC INSERT_PURCHASE_LJK '{cust[0]t.Code}','{cust.Name}','{prod.Code}','{prod.Name}','{quantity}','{formattedDatetime}'";
		//		}

		//		public static string Get()
		//		{
		//			return $"EXEC GET_PURCHASE";
		//		}

		//		public static string Get(DateTime date)
		//		{
		//			return $"EXEC GET_PURCHASE @DATE = '{date.Year}-{date.Month}-{date.Day}'";
		//		}

		//		public static string Get(DateTime date, string prodCode)
		//		{
		//			return $"EXEC GET_PURCHASE @DATE = '{date.Year}-{date.Month}-{date.Day}', @PROD_CODE = '{prodCode}'";
		//		}

		//		public static string GetByProdCode(string prodCode)
		//		{
		//			return $"EXEC GET_PURCHASE @PROD_CODE = '{prodCode}'";
		//		}

		//		public static string GetByCustCode(string custCode)
		//		{
		//			return $"EXEC GET_PURCHASE @CUST_CODE = '{custCode}'";
		//		}

		//		public static string Get(DateTime date, string prodCode, string custCode)
		//		{
		//			return $"EXEC GET_PURCHASE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}'";
		//		}

		//		public static string Update(DateTime date, string prodCode, string custCode, int amount)
		//		{
		//			return $"EXEC UPDATE_PURCHASE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}', {amount}";
		//		}

		//		public static string Delete(DateTime date, string prodCode, string custCode)
		//		{
		//			return $"EXEC DELETE_PURCHASE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}'";
		//		}
		//	}

		//	public class Sale
		//	{
		//		public static string Create(DateTime date, string prodCode, string custCode, int amount)
		//		{
		//			return $"EXEC CREATE_SALE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}', {amount}";
		//		}

		//		public static string Get()
		//		{
		//			return $"EXEC GET_SALE";
		//		}

		//		public static string Get(DateTime date)
		//		{
		//			return $"EXEC GET_SALE @DATE = '{date.Year}-{date.Month}-{date.Day}'";
		//		}

		//		public static string Get(DateTime date, string prodCode)
		//		{
		//			return $"EXEC GET_SALE @DATE = '{date.Year}-{date.Month}-{date.Day}', @PROD_CODE = '{prodCode}'";
		//		}

		//		public static string GetByProdCode(string prodCode)
		//		{
		//			return $"EXEC GET_SALE @PROD_CODE = '{prodCode}'";
		//		}

		//		public static string GetByCustCode(string custCode)
		//		{
		//			return $"EXEC GET_SALE @CUST_CODE = '{custCode}'";
		//		}

		//		public static string Get(DateTime date, string prodCode, string custCode)
		//		{
		//			return $"EXEC GET_SALE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}'";
		//		}

		//		public static string Update(DateTime date, string prodCode, string custCode, int amount)
		//		{
		//			return $"EXEC UPDATE_SALE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}', {amount}";
		//		}

		//		public static string Delete(DateTime date, string prodCode, string custCode)
		//		{
		//			return $"EXEC DELETE_SALE '{date.Year}-{date.Month}-{date.Day}', '{prodCode}', '{custCode}'";
		//		}
		//	}
		//}
	}
}
