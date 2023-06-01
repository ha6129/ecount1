using ECount.CoreBase;
using ECountSDK;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ECountSDK
{
	public class ProductSDK_DB2 : CommonDBSDK
	{
		//2. DB방식

		// 품목등록시 코드/이름/타입 등록됨
		public void Create(string sql)
		{
			DB.CallDB(sql);

		}
		public void Update(string sql)
		{
			DB.CallDB(sql);
		}
		public void Delete(string sql)
		{
			DB.CallDB(sql);
		}
		public List<Product> GetList()
		{
			var _products = new List<Product>();
			string sql = $"EXEC PRODUCT_SEARCH_HHY";

			void Callback(SqlDataReader reader)
			{
				while (reader.Read())
				{ // 하나의 row씩 읽는다.

					var prod = new Product();
					prod.Code = reader["CODE"] as string;
					prod.Name = reader["NAME"] as string;
					if (Enum.TryParse(reader["TYPE"].ToString(), out InfoType t))
					{
						prod.Type = t;
					}

					_products.Add(prod);
				}
			}
			DB.CallDB(sql, Callback);
			return _products;
		}
		public List<Product> Get(string code)
		{
			var _products = new List<Product>();
			string sql = $"EXEC PRODUCT_SEARCH_HHY '{code}'";
			void Callback(SqlDataReader reader)
			{
					while (reader.Read())
					{ // 하나의 row씩 읽는다.

						var prod = new Product();
						prod.Code = reader["CODE"] as string;
						prod.Name = reader["NAME"] as string;
						if (Enum.TryParse(reader["TYPE"].ToString(), out InfoType t))
						{
							prod.Type = t;
						}
					_products.Add(prod);
					}
			}
			DB.CallDB(sql, Callback);
			return _products;
		}
		public List<Product> GetByType(InfoType type)
		{
			var _products = new List<Product>();
			string sql = $"EXEC PRODUCT_SEARCH_HHY @TYPE = '{type}'";

			void Callback(SqlDataReader reader)
			{
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var prod = new Product();
						prod.Code = reader["CODE"] as string;
						prod.Name = reader["NAME"] as string;
						if (Enum.TryParse(reader["TYPE"].ToString(), out InfoType t))
						{
							prod.Type = t;
						}
						_products.Add(prod);
					}
				}
				else
				{
					_products = null;
				}
			}
			DB.CallDB(sql, Callback);
			return _products;
		}


	}
}
