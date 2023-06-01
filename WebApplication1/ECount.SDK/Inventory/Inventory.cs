using System;
using System.Collections.Generic;
using System.Text;

namespace ECountSDK
{
	public class Inventory
	{
		public Product Product { get; set; }
		public int? Quantity { get; set; }


		public Inventory() { }

		public Inventory(Product product, int? Quantity)
		{
			this.Product = product;
			this.Quantity = Quantity;
		}
	}



}
