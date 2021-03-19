using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Services.Interfaces
{
	public interface IDirectorService
	{
		Task<List<DirectorResponse>> GetDirectors();
		Task<DirectorResponse> GetDirector(Expression<Func<Director, bool>> expression);
		Task<DirectorResponse> GetDirector(int id);
	}
}
