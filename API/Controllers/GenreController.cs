using Appllication.Genres;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class GenreController : HomeController
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenreDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = new GetAllGenresQuery();

                // get response
                var response = await _mediator.Send(query);

                // use it
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            // create request
          
        }
    }
}
