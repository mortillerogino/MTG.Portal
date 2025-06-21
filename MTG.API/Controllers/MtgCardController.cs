using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MTG.API.Models;
using MTG.Application.Services.Interfaces;

namespace MTG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MtgCardController : ControllerBase
    {
        private readonly IMtgCardService mtgCardService;
        private readonly ILogger<MtgCardController> logger;

        public MtgCardController(IMtgCardService mtgCardService,
            ILogger<MtgCardController> logger)
        {
            this.mtgCardService = mtgCardService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCardRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var createCard = await mtgCardService.AddCardAsync(request.Name, request.Set, request.BinderId, request.Page, request.MtgTypes, request.MtgColors, cancellationToken);
                if (!createCard.IsSuccessful)
                {
                    logger.LogWarning("Card creation failed: {ErrorMessage}", createCard.ErrorMessage);
                    return BadRequest(createCard.ErrorMessage);
                }

                return Ok(createCard);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving cards.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
