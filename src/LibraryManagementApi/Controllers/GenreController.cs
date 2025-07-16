using Microsoft.AspNetCore.Mvc;
using LibraryManagementApi.Models;
using LibraryManagementApi.Dtos.Genre;
using LibraryManagementApi.Interfaces.Services;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genderService;
        private readonly ILogger<GenreController> _logger;

        public GenreController(ILogger<GenreController> logger, IGenreService genderService)
        {
            _logger = logger;
            _genderService = genderService;
        }

        // GET: api/Genre
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GenreResponseDto>))]
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                return Ok(await _genderService.GetAllGenresAsync());
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                _logger.LogError(ex, "An error occurred while retrieving genres.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreResponseDto))]
        public async Task<IActionResult> GetGenre(Guid id)
        {
            try
            {
                var genre = await _genderService.GetGenreByIdAsync(id);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                _logger.LogError(ex, "An error occurred while retrieving the genre.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        // PUT: api/Genre/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreResponseDto))]
        public async Task<IActionResult> PutGenre(Guid id, GenreUpdateDto genre)
        {
            try
            {
                var existingGenre = await _genderService.UpdateGenreAsync(genre);
                return Ok(existingGenre);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                _logger.LogError(ex, "An error occurred while updating the genre.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database.");
            }
        }

        // POST: api/Genre
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreResponseDto))]
        public async Task<ActionResult<Genre>> PostGenre(GenreRequestDto genre)
        {
            try
            {
                var createdGenre = await _genderService.AddGenreAsync(genre);
                return Ok(createdGenre);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                _logger.LogError(ex, "An error occurred while creating the genre.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data in the database.");
            }
        }

        // DELETE: api/Genre/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            try
            {
                await _genderService.DeleteGenreAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                _logger.LogError(ex, "An error occurred while deleting the genre.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database.");
            }
        }
    }
}
