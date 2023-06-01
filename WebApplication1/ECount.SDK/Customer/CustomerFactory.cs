using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public class CustomerFactory
	{
		public static ICustomerSDK CustFactory(string type)
		{
			if (type == "Inmemory")
			{
				return new CustomerSDK();
			}

			if (type == "DB")
			{
				return new CustomerSDK_DB();
			}

			throw new Exception("type정보에 일치하는 Class가 없습니다.");
		}
	}
}
