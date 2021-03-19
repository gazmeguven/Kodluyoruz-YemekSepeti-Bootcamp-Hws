using S8_Hotels.API.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S8_Hotels.API.Models.Derived
{
	public class Room : Resource
	{
		public string Name { get; set; }
		public int Rate { get; set; }
	}
}
