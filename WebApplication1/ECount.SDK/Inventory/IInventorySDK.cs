using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public interface IInventorySDK
	{
		List<Inventory> GetListStatus(DateTime datetime, bool includeZeroQuantity = false);

		List<Inventory> GetListStatus(); // 날짜 고려X

		List<Inventory> GetStatus(string code);

		List<Inventory> GetStatusByName(string name);

		List<Inventory> GetStatusByType(InfoType type);
		
	}
}
