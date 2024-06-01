using Microsoft.AspNetCore.Mvc;
using PokemonApp.Infrastructure.Exceptions;
using System.Net;

namespace PokemonApp.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ObjectResult HandleException(Exception ex)
        {
            if (ex?.InnerException is PokemonsDatabaseException)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: ex.InnerException.Message);
            }

            return Problem(
                statusCode: (int)HttpStatusCode.InternalServerError,
                detail: $"An unexpected error occurred. Error details: {ex.Message}"
            );
        }
    }
}