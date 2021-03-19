using FilmLibrary.Domain.Response;
using FilmLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmLibrary.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DirectorsController : ControllerBase
	{
		private readonly ILogger<DirectorsController> _logger;
		private readonly IDirectorService _directorService;

		public DirectorsController(ILogger<DirectorsController> logger, IDirectorService directorService)
		{
			_logger = logger;
			_directorService = directorService;
		}

		[HttpGet]
		[ProducesResponseType(typeof(DirectorResponse), StatusCodes.Status200OK)]
		public async Task<IActionResult> Get()
		{
			var directors = await _directorService.GetDirectors();
			return Ok(directors);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(DirectorResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(DirectorResponse), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Get(int id)
		{
			var customer = await _directorService.GetDirector(c => c.Id == id);

			if (customer == null)
				return NotFound();

			return Ok(customer);
		}

	}
}
