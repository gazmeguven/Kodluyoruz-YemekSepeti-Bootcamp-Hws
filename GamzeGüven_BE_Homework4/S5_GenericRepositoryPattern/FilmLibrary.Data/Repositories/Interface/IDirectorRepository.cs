using FilmLibrary.Data.Repositories.Core;
using FilmLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Data.Repositories.Interface
{
	public interface IDirectorRepository : IReadRepository<Director>, IWriteRepository<Director>
	{

	}
}
