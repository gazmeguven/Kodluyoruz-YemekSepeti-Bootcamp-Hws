using S1_DependencyInjectionLifetimes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S1_DependencyInjectionLifetimes.Services
{
	public class SampleService : IScopedService, ISingletonService, ITransientService
	{
		Guid _id;

		public SampleService()
		{
			_id = Guid.NewGuid();
		}

		public Guid GetId()
		{
			return _id;
		}
	}
}
