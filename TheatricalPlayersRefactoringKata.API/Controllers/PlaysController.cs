using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Data.Domain;
using TheatricalPlayersRefactoringKata.Data.Model.Input;

namespace TheatricalPlayersRefactoringKata.API.Controllers
{
    [Route("api/plays")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly PlaysService _playsService;
        public PlaysController(PlaysService playsService)
        {
            _playsService = playsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlayDTO data)
        {
            await _playsService.CreateAsync(data);
            return NoContent();
        }
    }
}
