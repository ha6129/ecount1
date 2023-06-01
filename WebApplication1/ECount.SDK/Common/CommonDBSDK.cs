using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public class CommonDBSDK
	{
		public static void Create<T>(T item)
			where T : CodeBase
		{
			string name = typeof(T).Name;

			Dictionary<string, object> parameter = new Dictionary<string, object>();
			parameter["@NAME"] = item.Name;
			parameter["@CODE"] = item.Code;
			if (item.Type != null) parameter["@TYPE"] = item.Type;
            if (item.safeqty != null)
                parameter["@SAFEQTY"] = item.safeqty;


			DB.ExceSPNon($"{name.ToUpper()}_INSERT_HHY", parameter);

			//return rowsAffected > 0 ? item : null;
		}

		public void Update<T>(string sql)
			where T : CodeBase
		{
			DB.CallDB(sql);

		}

		public void Delete<T>(string sql)
			where T : CodeBase
		{
			DB.CallDB(sql);
		}

		public List<T> GetList<T>(string sql)
			where T : CodeBase, new()
		{
			var tlist = new List<T>();

			void Callback(SqlDataReader reader)
			{
				while (reader.Read())
				{ // 하나의 row씩 읽는다.

					var item = new T();
					item.Code = reader["CODE"] as string;
					item.Name = reader["NAME"] as string;
                    if (Findtype(reader, "TYPE")||Findtype(reader,"SAFEQTY"))
					{
						if (Enum.TryParse(reader["TYPE"].ToString(), out InfoType t))
						{
							item.Type = t;
						}
                        item.safeqty = reader["SAFEQTY"] as int?;
					}
					tlist.Add(item);
				}
			}
			DB.CallDB(sql, Callback);
			return tlist;
		}

		public List<T> Get<T>(string sql)
			where T : CodeBase, new()
		{
			var tlist = new List<T>();

			void Callback(SqlDataReader reader)
			{
				while (reader.Read())
				{ // 하나의 row씩 읽는다.

					var item = new T();
					item.Code = reader["CODE"] as string;
					item.Name = reader["NAME"] as string;
                    item.safeqty = reader["SAFEQTY"] as int?;
					if (Findtype(reader, "TYPE"))
					{
						if (Enum.TryParse(reader["TYPE"].ToString(), out InfoType t))
						{
							item.Type = t;
						}
					}
					tlist.Add(item);
				}
			}
			DB.CallDB(sql, Callback);
			return tlist;
		}
		public List<T> GetByType<T>(string sql)
			where T : CodeBase, new()
		{
			var tlist = new List<T>();

			void Callback(SqlDataReader reader)
			{
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						var item = new T();
						item.Code = reader["CODE"] as string;
						item.Name = reader["NAME"] as string;
                        item.safeqty = reader["SAFEQTY"] as int?;

                        if (Enum.TryParse(reader["TYPE"].ToString(), out InfoType t))
						{
							item.Type = t;
						}

						tlist.Add(item);
					}
				}
				else
				{
					tlist = null;
				}
			}
			DB.CallDB(sql, Callback);
			return tlist;
		}

		public bool Findtype(SqlDataReader reader, string columnName)
		{
			for (int i = 0; i < reader.FieldCount; i++)
			{

				if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
					return true;
			}
			return false;
		}
	}

}

