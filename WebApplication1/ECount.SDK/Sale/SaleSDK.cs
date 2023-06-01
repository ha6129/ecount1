using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ECountSDK
{
	public class SaleSDK : ISaleSDK
	{
		private static List<Sale> _sales = new List<Sale>();
		//private List<Product> _products = new List<Product>();
		public SaleSDK()
		{

		}
		public void Create(Sale sale)
		{
			_sales.Add(sale);
			
		}
		public void Update(Sale sale)
		{

				// purchase list에서 수정할 라인을 찾기
				var line = _sales.Find(p => p.Index == sale.Index);

				if (line == null)
				{
					throw new ArgumentException("Index not found");
				}
				// 수정된 값으로 라인 업데이트
				line.Product = sale.Product;
				line.Customer = sale.Customer;
				//유효성 추가해줘야함
				line.Quantity = sale.Quantity;
				line.DataTime = sale.DataTime;
			
		}
		public void Delete(List<Sale> sale)
		{
			foreach (var sal in sale)
			{
				// purchase list에서 삭제할 라인을 찾기
				_sales.RemoveAll(p => p.Index == sal.Index);
			}
		}
		//판매조회
		public List<Sale> GetHistory()
		{
			return _sales;
		}

		public List<Sale> GetHistory(string code)
		{
			return _sales.FindAll(x => x.Product.Code == code);
		}
		public List<Sale> GetHistoryByCustCode(string code)
		{
			return _sales.FindAll(x => x.Customer.Code == code);
		}

		public List<Sale> GetHistoryByName(string name)
		{
			return _sales.FindAll(x => x.Product.Name == name);
		}


		public List<Sale> GetHistoryByType(InfoType type)
		{
			return _sales.FindAll(x => x.Product.Type == type);
		}
	}
}
