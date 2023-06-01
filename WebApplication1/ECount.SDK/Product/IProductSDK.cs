using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public interface IProductSDK
	{
		void Create(Product product);


		void Update(Product product);

		void Delete(List<Product> products);

		//전체품목 가져오기
		List<Product> GetList();

		List<Product> Get(string code);

		List<Product> GetByType(InfoType type);
	}
}
