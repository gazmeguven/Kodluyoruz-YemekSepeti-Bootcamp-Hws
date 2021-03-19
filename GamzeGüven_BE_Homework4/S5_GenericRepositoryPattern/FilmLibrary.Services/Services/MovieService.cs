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
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository _movieRepository;

		public MovieService(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public async Task<MovieResponse> AddMovie(Movie movie)
		{
			var result = await _movieRepository.Add(movie);

			return new MovieResponse
			{
				Id = result.Id,
				Title = result.Title,
				AirDate = result.AirDate.Date
			};
		}

		public async Task<bool> DeleteMovie(int id)
		{
			var result = await _movieRepository.Delete(id);

			return result;
		}

		public async Task<MovieResponse> GetMovie(Expression<Func<Movie, bool>> expression)
		{
			var result = await _movieRepository.Get(expression);

			return new MovieResponse
			{
				Id = result.Id,
				Title = result.Title,
				AirDate = result.AirDate.Date
			};
		}

		public async Task<MovieResponse> GetMovie(int id)
		{
			var result = await _movieRepository.GetById(id);

			return new MovieResponse
			{
				Id = result.Id,
				Title = result.Title,
				AirDate = result.AirDate.Date
			};
		}

		public async Task<List<MovieResponse>> GetMovies()
		{
			var result = await _movieRepository.GetAll();

			return result.Select(c => new MovieResponse
			{
				Id = c.Id,
				Title = c.Title,
				AirDate = c.AirDate.Date
			}).ToList();
		}

		public async Task<MovieResponse> UpdateMovie(Movie movie)
		{
			var result = await _movieRepository.Update(movie);

			return new MovieResponse
			{
				Id = result.Id,
				Title = result.Title,
				AirDate = result.AirDate.Date
			};
		}
	}
}
