using System;
using System.Collections.Generic;
using System.Text;

namespace ECountSDK
{
	public class SDK
	{
		public ProductSDK Product;
		public PurchaseSDK Purchase;
		public SaleSDK Sale;
		public InventorySDK Inventory;

		//추가
		//추가

		public SDK()
		{
			this.Product = new ProductSDK();
			this.Purchase = new PurchaseSDK();
			this.Sale = new SaleSDK();
			this.Inventory = new InventorySDK();
		}
	}
}
