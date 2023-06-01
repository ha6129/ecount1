using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ECount.CoreBase;
using ECountSDK;

namespace ECountSDK
{
	public class InventorySDK_DB : IInventorySDK
	{
		private List<Purchase> _purchases = new List<Purchase>();
		private List<Sale> _sales = new List<Sale>();
		public static List<Inventory> _inventory = new List<Inventory>();
		public PurchaseSDK_DB pursdk = new PurchaseSDK_DB();
		public SaleSDK_DB salsdk = new SaleSDK_DB();

        // 재고 현황의 정보를 최신화 한다
        // 수동으로 해당 함수를 호출해 주어야 한다.

        public void Refresh()
		{
			_purchases = pursdk.GetHistory();
			_sales = salsdk.GetHistory();
		}
		
		public List<Inventory> GetListStatus(DateTime datetime, bool includeZeroQuantity = false)
		{
			Refresh();
			_inventory = new List<Inventory>();

			foreach (var item2 in _purchases)
			{
				if (DateTime.Compare(item2.DataTime, datetime) <= 0) // 입력된 날짜보다 이전일 때만 계산
				{
					var totalpurchases = _inventory.Find(x => x.Product.Code == item2.Product.Code);
						if (totalpurchases == null) // 배열에 값이 없다면 (재고현황 없는 구매내역)
						{
							_inventory.Add(new Inventory(item2.Product, item2.Quantity));
						}
						else
						{
						// var inven =_inventory.Find(x => x.Product.Code == item2.Product.Code);

							totalpurchases.Quantity += item2.Quantity;
						}
				}
				else
				{
					continue;
				}
			}
			//판매는 재고(inventory)에서 빼주기
			foreach (var item3 in _sales)
			{
				if (DateTime.Compare(item3.DataTime, datetime) <= 0)
				{
					var totalsales = _inventory.Find(x => x.Product.Code == item3.Product.Code);
					if (totalsales == null) // 배열에 값이 없다면 (재고현황 없는 구매내역)
					{
						_inventory.Add(new Inventory(item3.Product, -item3.Quantity));
					}
					else
					{
						// var inven =_inventory.Find(x => x.Product.Code == item2.Product.Code);
						totalsales.Quantity -= item3.Quantity;
					}
				}
				else
				{
					continue;
				}
			}

            // 재고가 0인 품목들을 조회하지 않을 경우, 0인 품목들은 필터링
            if (!includeZeroQuantity) {
                _inventory = _inventory.Where(item => item.Quantity != 0).ToList();
            }
            return _inventory;
		}


		public List<Inventory> GetListStatus() // 날짜 고려X
		{
			Refresh();
			// 구매는 재고(inventory)에서 더해주기
			_inventory = new List<Inventory>();

			foreach (var item2 in _purchases)
			{
				var totalpurchases = _inventory.Find(x => x.Product.Code == item2.Product.Code);
				if (totalpurchases == null) // 배열에 값이 없다면 (재고현황 없는 구매내역)
				{
					_inventory.Add(new Inventory(item2.Product, item2.Quantity));
				}
				else
				{
					// var inven =_inventory.Find(x => x.Product.Code == item2.Product.Code);
					totalpurchases.Quantity += item2.Quantity;
				}
			}

			//판매는 재고(inventory)에서 빼주기
			foreach (var item3 in _sales)
			{
				var totalsales = _inventory.Find(x => x.Product.Code == item3.Product.Code);
				if (totalsales == null) // 배열에 값이 없다면 (재고현황 없는 구매내역)
				{
					_inventory.Add(new Inventory(item3.Product, -item3.Quantity));
				}
				else
				{
					totalsales.Quantity -= item3.Quantity;
				}
			}

			return _inventory;
		}

		public List<Inventory> GetStatus(string code)
		{
			_inventory = GetListStatus(); //파일저장식일때 getliststatus() 함수를 호출해 인벤토리 값을 한번 불러옴

			var temp = _inventory.Find(x => x.Product.Code == code);

			Console.WriteLine($"{temp.Product.Code} {temp.Quantity}");

			return _inventory;
		}

		public List<Inventory> GetStatusByName(string name)
		{
			_inventory = GetListStatus();
			var temp = _inventory.FindAll(x => x.Product.Name == name);

			foreach(var item in temp)
			{
				Console.WriteLine(item.Product.Code + " " + item.Product.Name + " " + item.Quantity);
			}
			return _inventory;
		}

		public List<Inventory> GetStatusByType(InfoType type)
		{
			_inventory = GetListStatus();
			var temp = _inventory.FindAll(x => x.Product.Type == type);

			foreach (var item in temp)
			{
				Console.WriteLine(item.Product.Code + " " + item.Product.Name + " " + item.Quantity);
			}
			return _inventory;
		}

	}
}
