using FilmLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Domain.Entities
{
	public class Movie : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime AirDate { get; set; }
	}
}
