using System;
using System.Runtime.Serialization;

namespace FilmLibrary.Domain.Exceptions
{
	public class DatabaseAccessException : Exception
	{
		public DatabaseAccessException()
		{
		}

		public DatabaseAccessException(string message) : base(message)
		{
		}

		public DatabaseAccessException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}