using ECountSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount.SDK
{
	public interface Base
	{
		int Index { get; set; }
		Product Product { get; set; }
		int? Quantity { get; set; }
		DateTime DataTime { get; set; }
		Customer Customer { get; set; }
		string Type { get; set; }

	}
}
