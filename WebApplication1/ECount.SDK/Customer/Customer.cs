using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECountSDK
{
	public class Customer : CodeBase
	{

		public string Code { get; set; }
		public string Name { get; set; }
		public InfoType? Type { get; set; }
        public int? safeqty { get; set; }
		

		public Customer() { }

		public Customer(string custcode, string custname)
		{
			this.Code = custcode;
			this.Name = custname;
		}
	}
}
