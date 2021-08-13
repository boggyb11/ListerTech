using ListerTechTest.Data.DTO.Ward.Requests;
using ListerTechTest.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListerTechTest.Controllers
{
    public class WardController : BaseController
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddWard(AddWardRequest request)
        {
            var result = _wardService.AddWard(request);

            if (result.Succeeded)
                return Ok(result.Content);

            return BadRequest(result.Error);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetActiveWardPatients(int wardId)
        {
            var result = _wardService.GetActiveWardPatients(wardId);

            if (result.Succeeded)
                return Ok(result.Content);

            return BadRequest(result.Error);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetWards()
        {
            var result = _wardService.GetWards();

            if (result.Succeeded)
                return Ok(result.Content);

            return BadRequest(result.Error);
        }
    }
}
