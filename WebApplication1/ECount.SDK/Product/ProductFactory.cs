using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public class ProductFactory
	{
		public static IProductSDK ProdFactory(string type)
		{

			if (type == "Inmemory")
			{
				return new ProductSDK();
			}

			if (type == "DB")
			{
				return new ProductSDK_DB();
			}

			throw new Exception("type정보에 일치하는 Class가 없습니다.");
		}
	}
}
