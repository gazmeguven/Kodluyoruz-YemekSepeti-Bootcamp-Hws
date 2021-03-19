using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw5_Dapper.Models
{
	public class CountryRegion
	{
		public int CountryRegionID { get; set; }
		public string CountryRegionCode { get; set; }
		public string Name { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
