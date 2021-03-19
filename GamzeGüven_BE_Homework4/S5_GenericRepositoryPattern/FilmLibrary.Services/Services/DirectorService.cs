using FilmLibrary.Data.Repositories.Interface;
using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Response;
using FilmLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Services.Services
{
	public class DirectorService : IDirectorService
	{ 
		private readonly IDirectorRepository _directorRepository;

		public DirectorService(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<DirectorResponse> GetDirector(Expression<Func<Director, bool>> expression)
		{
			var result = await _directorRepository.Get(expression);

			return new DirectorResponse
			{
				Id = result.Id,
				FullName = string.Concat(result.FirstName, result.LastName),
				NumberOfAwards = result.NumberOfAwards
			};
		}

		public async Task<DirectorResponse> GetDirector(int id)
		{
			var result = await _directorRepository.GetById(id);

			return new DirectorResponse
			{
				Id = result.Id,
				FullName = string.Concat(result.FirstName, result.LastName),
				NumberOfAwards = result.NumberOfAwards
			};
		}

		public async Task<List<DirectorResponse>> GetDirectors()
		{
			var result = await _directorRepository.GetAll();

			return result.Select(c => new DirectorResponse
			{
				Id = c.Id,
				FullName = string.Concat(c.FirstName, c.LastName),
				NumberOfAwards = c.NumberOfAwards
			}).ToList();
		}
	}
}
