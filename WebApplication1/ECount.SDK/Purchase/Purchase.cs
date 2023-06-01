using ECount.CoreBase;
using ECount.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECountSDK
{
	[Serializable]
	public class Purchase : Base
	{
		// 구매에는 상품, 수량 정보가 필요하다
		public int Index { get; set; }
		public Product Product { get; set; }
		public int? Quantity { get; set; }
		public DateTime DataTime { get; set; }
		public Customer Customer { get; set; }
		public string Type { get; set; } = "구매";

		public static int ID = 1;
		public Purchase() { }

		public Purchase(Product product, int? quantity, DateTime datatime, Customer customer)
		{
			this.Index = ID++;
			this.Product = product;
			this.Quantity = quantity;
			this.DataTime = datatime;
			this.Customer = customer;
		}

		// 구매 tostring 형식은 코드 / 이름 / 수량
		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3} {4}", this.Customer, this.Product.Code, this.Product.Name, this.Quantity, this.DataTime.ToShortDateString());
		}

	}
}
