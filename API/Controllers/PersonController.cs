using System.Net;
using Application.Exeption;
using Application.Persons;
using Domain.DTO;
using Domain.DTO.GenresDTO;
using Domain.DTO.PersonDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonController : HomeController
    {
        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonDTO>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreatePersonDTO model)
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
        public async Task<ActionResult<int>> Edit(Guid id, [FromBody] EditPersonDTO model)
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
        public async Task<ActionResult<int>> Delete(Guid id)
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
}