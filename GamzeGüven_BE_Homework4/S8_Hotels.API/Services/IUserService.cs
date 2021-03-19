using S8_Hotels.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S8_Hotels.API.Services
{
	public interface IUserService
	{
		Task<UserInfo> Authenticate(TokenRequest req);
	}
}
