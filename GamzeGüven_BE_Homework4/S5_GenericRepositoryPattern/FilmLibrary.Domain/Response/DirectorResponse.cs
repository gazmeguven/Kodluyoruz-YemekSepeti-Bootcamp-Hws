using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.Domain.Response
{
	public class DirectorResponse
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public int NumberOfAwards { get; set; }
	}
}
