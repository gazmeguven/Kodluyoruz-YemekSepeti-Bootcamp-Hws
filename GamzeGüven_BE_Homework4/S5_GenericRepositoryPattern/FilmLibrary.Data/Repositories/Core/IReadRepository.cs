using FilmLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Data.Repositories.Core
{
	public interface IReadRepository<T> where T : IEntity
	{
		Task<T> GetById(int id);
		Task<T> Get(Expression<Func<T, bool>> expression);
		Task<IQueryable<T>> GetAll();
		Task<IQueryable<T>> GetMany(Expression<Func<T, bool>> expression);
	}
}
