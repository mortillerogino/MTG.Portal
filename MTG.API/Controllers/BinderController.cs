using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTG.API.Models;
using MTG.Application.Services.Interfaces;

namespace MTG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinderController : ControllerBase
    {
        private readonly IBinderService binderService;
        private readonly ILogger<BinderController> logger;

        public BinderController(IBinderService binderService,
            ILogger<BinderController> logger)
        {
            this.binderService = binderService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateBinderRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await binderService.CreateBinderAsync(request.Name, request.Description, cancellationToken);

                if (!result.IsSuccessful)
                {
                    logger.LogWarning("Binder creation failed: {ErrorMessage}", result.ErrorMessage);
                    return BadRequest(result.ErrorMessage);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the binder.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        
    }
}
