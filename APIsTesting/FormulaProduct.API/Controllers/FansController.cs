using FormulaProduct.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaProduct.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class FansController : ControllerBase
    {
        private readonly IFanService _fastaService;

        public FansController(IFanService fanService)
        {
            this._fastaService= fanService;
        }



        [HttpGet(Name ="GetFans")]
        public async Task<IActionResult>Get()
        {
            var fans = await _fastaService.GetAllFans();

            if(fans.Any())
                return Ok(fans); // StatusCode 200

            return NotFound();
        }

    }
}
