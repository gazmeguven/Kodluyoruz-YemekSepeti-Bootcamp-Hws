using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Domain.Response
{
	public class MovieResponse
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime AirDate { get; set; }
	}
}
