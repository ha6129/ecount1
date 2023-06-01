using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void CallBack(SqlDataReader reader);

namespace ECount.CoreBase
{
	public class DB
	{
		private static string connectString = "Server=10.10.9.241, 25111;Database=ACCT_AC;Uid =ecountdev;Pwd=acct@0000";

		//공통부분
		public static void CallDB(string sql)
		{
			using (SqlConnection conn = new SqlConnection(connectString))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand(sql, conn);

				var count = cmd.ExecuteNonQuery();   // 영향받은 갯수 -> 예를 들어 1이 아닐 시 오류처리
													// while문 내용을 callback();으로 대체하는 방법 생각
			}
		}

		public static void CallDB(string sql, CallBack callback)
		{
			using (SqlConnection conn = new SqlConnection(connectString))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand(sql, conn);

				SqlDataReader reader = cmd.ExecuteReader();

				callback(reader);
			}
		}

		public static int ExceSPNon(string SPName, Dictionary<string, object> parameter)
		{
			int rowsAffected = 0;
			using (SqlConnection conn = new SqlConnection(connectString))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand(SPName, conn);
				cmd.CommandType = CommandType.StoredProcedure;

				foreach (KeyValuePair<string, object> val in parameter)
				{
					cmd.Parameters.AddWithValue(val.Key, $"{val.Value}");
				}
				rowsAffected = cmd.ExecuteNonQuery();
			}
			return rowsAffected;
		}
	}
}
