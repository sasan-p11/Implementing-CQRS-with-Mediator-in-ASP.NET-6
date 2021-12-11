using Application.Photos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class PhotosController : HomeController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] Add.Command command)
    {
        return Ok(await Mediator.Send(command));
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(string id)
    // {
    //     return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    // }

    // [HttpPost("{id}/setMain")]
    // public async Task<IActionResult> SetMain(string id)
    // {
    //     return HandleResult(await Mediator.Send(new SetMain.Command { Id = id }));
    // }
}

