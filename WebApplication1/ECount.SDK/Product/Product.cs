using ECount.CoreBase;
using System;
using System.Collections.Generic;
using System.Text;


namespace ECountSDK
{
	[Serializable]
	public class Product : CodeBase
	{
		// product 정보담고있는 객체
		
		public string Code { get; set; }
		public string Name { get; set; }
		public InfoType? Type { get; set; }
        public int? safeqty { get; set; }

		public Product()
		{ }

		public Product(string code, string name, InfoType type, int safeqty)
		{
			this.Code = code;
			this.Name = name;
			this.Type = type;
            this.safeqty = safeqty;
		}


		public override string ToString()
		{
			//return this.Code + " " + this.Name + " " + this.Type;
			return string.Format("{0} {1} {2} {3}", this.Code, this.Name, this.Type, this.safeqty);
				
		}
	}
}
