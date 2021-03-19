using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using S1_DependencyInjectionLifetimes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S1_DependencyInjectionLifetimes.Controllers
{

	/*
	 singleton : uygulama ilk ayağa kalktığı anda, servisin tek bir instance’ı oluşturularak memory’de tutulur ve 
	daha sonrasında her servis çağrısında bu instance gönderilir.
	
	scoped : her request için tek bir instance yaratılmasını sağlayan lifetime seçeneğidir. 
	request cycle’ı tamamlanana kadar gerçekleşen servis çağrılarında daha önce oluşturulan instance gönderilir.
	daha sonra yeni bir request başladığında farklı bir instance oluşturulur.
	
	transient : her servis çağrısında yeni bir instance oluşturulur.
	 */

	[ApiController]
	[Route("[controller]")]
	public class LifetimesController : ControllerBase
	{
		private readonly ITransientService _transientService1;
		private readonly ITransientService _transientService2;
		private readonly IScopedService _scopedService1;
		private readonly IScopedService _scopedService2;
		private readonly ISingletonService _singletonService1;
		private readonly ISingletonService _singletonService2;

		//Constructor Injection
		public LifetimesController(ITransientService transientService1,
										ITransientService transientService2,
										IScopedService scopedService1,
										IScopedService scopedService2,
										ISingletonService singletonService1,
										ISingletonService singletonService2)
		{
			_transientService1 = transientService1;
			_transientService2 = transientService2;
			_scopedService1 = scopedService1;
			_scopedService2 = scopedService2;
			_singletonService1 = singletonService1;
			_singletonService2 = singletonService2;
		}

		[HttpGet]
		[Route("GetActionInjection")]
		//Method Injection
		public string GetActionInjection([FromServices] IScopedService scopedService)
		{
			string result = $"ScopedService: {scopedService.GetId()}";
			return result;
		}


		[HttpGet]
		[Route("GetPropertynInjection")]
		//Property Injection -- kendimiz çağırmalıyız.
		public string GetPropertynInjection()
		{
			var services = this.HttpContext.RequestServices;
			var scopedService = (IScopedService)services.GetService(typeof(IScopedService));
			string res = $"Scoped Property: {scopedService.GetId()}";
			return res;
		}


		[HttpGet]
		public string Get()
		{
			string result = $"Transient1 : {_transientService1.GetId()} {Environment.NewLine}" +
							$"Transient2 : {_transientService2.GetId()} {Environment.NewLine}" +
							$"Scoped1    : {_scopedService1.GetId() } {Environment.NewLine}" +
							$"Scoped2    : {_scopedService2.GetId()} {Environment.NewLine}" +
							$"Singleton1 : {_singletonService1.GetId() } {Environment.NewLine}" +
							$"Singleton2 : {_singletonService2.GetId()} {Environment.NewLine}";

			return result;
		}
	}
}
