using FilmLibrary.Data.Repositories.Core;
using FilmLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Data.Repositories.Interface
{
	public interface IMovieRepository : IReadRepository<Movie>, IWriteRepository<Movie>
	{
	}
}
