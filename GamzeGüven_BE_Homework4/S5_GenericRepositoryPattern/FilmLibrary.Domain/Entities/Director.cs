using FilmLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Domain.Entities
{
	public class Director : IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int NumberOfAwards { get; set; }

	}
}
