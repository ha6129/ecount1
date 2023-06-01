using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public class PurchaseFactory
	{
		public static IPurchaseSDK PurFactory(string type)
		{
			if (type == "Inmemory")
			{
				return new PurchaseSDK();
			}

			if (type == "DB")
			{
				return new PurchaseSDK_DB();
			}

			throw new Exception("type정보에 일치하는 Class가 없습니다.");
		}
	}
}
