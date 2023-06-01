using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECountSDK
{
	public interface ICustomerSDK
	{
		void Create(Customer customer);

		void Update(Customer customers);

		void Delete(List<Customer> customers);

		//전체거래처 가져오기
		List<Customer> GetList();

		//특정거래처 가져오기
		List<Customer> Get(string code);

	}
}
