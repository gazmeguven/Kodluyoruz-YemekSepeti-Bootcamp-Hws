using System;
using System.Runtime.Serialization;

namespace FilmLibrary.Domain.Exceptions
{
	public class ConcurrencyException : Exception
	{
		public ConcurrencyException()
		{
		}

		public ConcurrencyException(string message) : base(message)
		{
		}

		public ConcurrencyException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}