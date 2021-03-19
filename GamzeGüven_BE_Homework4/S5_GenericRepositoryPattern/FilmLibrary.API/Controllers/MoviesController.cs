using FilmLibrary.Domain.Entities;
using FilmLibrary.Domain.Response;
using FilmLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FilmLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _movieService;

        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _movieService.GetMovie(id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        [Route("AddMovie")]
        public async Task<IActionResult> Post([FromBody] Movie movie)
        {
            var addedMovie = await _movieService.AddMovie(movie);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Movie movie)
        {
            var updatedMovie = await _movieService.UpdateMovie(movie);

            if (updatedMovie == null)
                return BadRequest();

            return Ok(updatedMovie);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMovie = await _movieService.DeleteMovie(id);

            if (deletedMovie == false)
                return BadRequest();

            return Ok();

        }

    }
}
