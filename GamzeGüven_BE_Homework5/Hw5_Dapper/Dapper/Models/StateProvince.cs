using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw5_Dapper.Models
{
	public class StateProvince
	{
		public int StateProvinceID { get; set; }
		public string Name { get; set; }
		public string StateProvinceCode { get; set; }
		public virtual List<SalesTaxRate> stateNames { get; set; }

	}
}
