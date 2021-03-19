using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw5_Dapper.Models
{
	public class SalesTaxRate
	{
		public int SalesTaxRateId { get; set; }
		public int StateProvinceId { get; set; }
		public double TaxRate { get; set; }
		public virtual StateProvince StateProvince { get; set; }
	}
}
