using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ECountSDK
{
	public class PurchaseSDK : IPurchaseSDK
	{
		private static List<Purchase> _purchases = new List<Purchase>();
		//private static List<Product> _products = new List<Product>();
		//private static List<Customer> _customer = new List<Customer>();

		public PurchaseSDK()
		{
		}
		//1.인메모리
		public void Create(Purchase purchase)
		{
			//var product = ProductSDK._products.Find(x => x.Code == code);
			//var customer = CustomerSDK._custList.Find(x => x.Code == custcode);
			//var purchase = new Purchase(product, quantity, datatime, customer);

			_purchases.Add(purchase);

		}

		public void Update(Purchase purchase)
		{
				// purchase list에서 수정할 라인을 찾기
				var line = _purchases.Find(p => p.Index == purchase.Index);

				if (line == null)
				{
					throw new ArgumentException("Index not found");
				}

				// _products에서 코드로 제품 찾기
				var product = ProductSDK._products.Find(x => x.Code == purchase.Product.Code);

				//셀렉박스가 아니라 예외처리해둠.
				if (product == null)
				{
					throw new ArgumentException("Product code not found");
				}

				// _custList에서 코드로 고객 찾기
				var customer = CustomerSDK._custList.Find(x => x.Code == purchase.Customer.Code); ;

				if (customer == null)
				{
					throw new ArgumentException("Customer code not found");
				}
				// 수정된 값으로 라인 업데이트
				line.Product = product;
				line.Customer = customer;
				//유효성 추가해줘야함 > controller에서 ㅎ줌
				line.Quantity = purchase.Quantity;
				line.DataTime = purchase.DataTime;
			
		}
		public void Delete(List<Purchase> purchase)
		{
			foreach (var pur in purchase)
			{
				// purchase list에서 삭제할 라인을 찾기
				_purchases.RemoveAll(p => p.Index == pur.Index);
			}
		}
		//구매조회
		public List<Purchase> GetHistory()
		{
			return _purchases;
		}

		public List<Purchase> GetHistory(string code)
		{
			return _purchases.FindAll(x => x.Product.Code == code);
		}

		public List<Purchase> GetHistoryByCustCode(string code)
		{
			return _purchases.FindAll(x => x.Customer.Code == code);
		}

		//public List<Purchase> GetHistoryByName(string name)
		//{
		//	return _purchases.FindAll(x => x.Product.Name == name);
		//}


		//public List<Purchase> GetHistoryByType(ProductType type)
		//{
		//	return _purchases.FindAll(x => x.Product.Type == type);
		//}
	}
}
