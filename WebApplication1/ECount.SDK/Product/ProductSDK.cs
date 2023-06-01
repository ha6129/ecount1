using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace ECountSDK
{
	// 인메모리 클래스
	public class ProductSDK : IProductSDK
	{

		public static List<Product> _products = new List<Product>();
		public ProductSDK()
		{
			//_products.Clear();
			//_products.Add(new Product("0001", "새우깡", ProductType.Snack));
			//_products.Add(new Product("0002", "홈런볼", ProductType.Snack));
		}

		// 품목등록시 코드/이름/타입 등록됨
		public void Create(Product product)
		{
			_products.Add(product);
		}

		public void Update(Product product)
		{
				Product prod = _products.Find(x => x.Code == product.Code);

					prod.Name = product.Name;
					prod.Type = product.Type;
		}
		public void Delete(List<Product> products)
		{
			foreach (var product in products)
			{
				Product prod = _products.Find(x => x.Code == product.Code);

					_products.Remove(prod);
			}
		}

		//전체품목 가져오기
		public List<Product> GetList()
		{
			return _products;
		}

		//특정품목 가져오기
		//Find > 동일한 이름인거 하나만 반환(코드는 고유하기때문에 Find)
		// 3. x => x.Code == code 의미

		public List<Product> Get(string code)
		{
			return _products.FindAll(x => x.Code.Contains(code));
		}
		//Findall > 전체 반환

		public List<Product> GetByType(InfoType type)
		{
			return _products.FindAll(x => x.Type == type);
		}
	}
}
