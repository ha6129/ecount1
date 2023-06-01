using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public interface ISaleSDK
	{
		void Create(Sale sale);

		void Update(Sale sale);

		void Delete(List<Sale> sale);

		//판매조회
		List<Sale> GetHistory();


		List<Sale> GetHistory(string code);

		List<Sale> GetHistoryByCustCode(string code);


		List<Sale> GetHistoryByName(string name);

		List<Sale> GetHistoryByType(InfoType type);

	}
}
