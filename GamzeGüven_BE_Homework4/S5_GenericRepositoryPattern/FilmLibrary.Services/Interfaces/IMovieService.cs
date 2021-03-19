using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Services.Interfaces
{
	public interface IMovieService
	{
        Task<List<MovieResponse>> GetMovies();
        Task<MovieResponse> GetMovie(Expression<Func<Movie, bool>> expression);
        Task<MovieResponse> GetMovie(int id);
        Task<MovieResponse> AddMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
        Task<MovieResponse> UpdateMovie(Movie movie);
    }
}
