using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public interface IPurchaseSDK
	{
		void Create(Purchase purchase);
		void Update(Purchase purchase);
		void Delete(List<Purchase> purchase);
		//구매조회
		List<Purchase> GetHistory();
		List<Purchase> GetHistory(string code);
		List<Purchase> GetHistoryByCustCode(string code);
		//List<Purchase> GetHistoryByName(string name);
		//List<Purchase> GetHistoryByType(ProductType type);

	}
}
