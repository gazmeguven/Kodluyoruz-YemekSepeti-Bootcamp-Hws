using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S1_DependencyInjectionLifetimes.Interfaces
{
	public interface IScopedService
	{
		Guid GetId();
	}
}
