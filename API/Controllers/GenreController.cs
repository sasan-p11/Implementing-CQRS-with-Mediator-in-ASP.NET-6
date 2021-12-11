using Application.Exeption;
using Application.Genres;
using Domain.DTO;
using Domain.DTO.GenresDTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
public class GenreController : HomeController
{
  
    [HttpGet]
    public async Task<ActionResult<List<GenreDTO>>> Get()
    {
        return Ok(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GenreDTO>> Get(int id)
    {
        return Ok(await Mediator.Send(new Details.Query { Id = id}));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CreateGenreDTO model)
    {
        try
        {
            var command = new Create.Command(model);
            var response = await Mediator.Send(command);
            return StatusCode((int)HttpStatusCode.Created, response);
        }
        catch (InvalidRequestBodyException ex)
        {
            return BadRequest(new BaseResponseDTO
            {
                IsSuccess = false,
                Errors = ex.Errors
            });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<int>> Edit(int id, [FromBody] EditGenreDTO model)
    {
        model.Id = id;
        try
        {
            var command = new Edit.Command(model);
            var response = await Mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, response);
        }
        catch (InvalidRequestBodyException ex)
        {
            return BadRequest(new BaseResponseDTO
            {
                IsSuccess = false,
                Errors = ex.Errors
            });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        try
        {
            var command = new Delete.Command(id);
            var response = await Mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, response);
        }
        catch (InvalidRequestBodyException ex)
        {
            return BadRequest(new BaseResponseDTO
            {
                IsSuccess = false,
                Errors = ex.Errors
            });
        }
    }
}

