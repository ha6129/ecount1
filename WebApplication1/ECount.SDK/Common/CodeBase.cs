using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount.CoreBase
{
	public interface CodeBase
	{
		string Code { get; set; }
		string Name { get; set; }
		InfoType? Type { get; set; }
        int? safeqty { get; set; }

	}
}
