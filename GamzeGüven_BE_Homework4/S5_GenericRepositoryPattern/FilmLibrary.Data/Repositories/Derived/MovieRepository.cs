using FilmLibrary.Data.Repositories.Core;
using FilmLibrary.Data.Repositories.Interface;
using FilmLibrary.Domain.Entities;

namespace FilmLibrary.Data.Repositories.Derived
{
	public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
	{

	}
}
