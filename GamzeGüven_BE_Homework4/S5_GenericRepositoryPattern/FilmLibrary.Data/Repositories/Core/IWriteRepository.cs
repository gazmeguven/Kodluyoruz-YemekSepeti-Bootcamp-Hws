using FilmLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Data.Repositories.Core
{
	public interface IWriteRepository<T> where T : IEntity
	{
		Task<T> Add(T entity);
		Task<T> Update(T entity);
		Task<bool> Delete(T entity);
		Task<bool> Delete(int id);
	}
}
