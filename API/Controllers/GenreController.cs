using Appllication.Genres;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class GenreController : HomeController
{
    [HttpGet]
    public async Task<ActionResult<List<GenreDTO>>> Get()
    {
        return Ok(await Mediator.Send(new GetGenres.Query()));
    }
}

