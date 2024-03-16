using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
namespace ontion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
    private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStringLocalizer<LanguageController> _localizer;

        public LanguageController(IHttpContextAccessor httpContextAccessor, IStringLocalizer<LanguageController> localizer)
        {
            _httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
        }

        [HttpGet]
        [Route("api/language")]
        public IActionResult GetLanguage()
        {
            // Get language preference from request headers or query parameters
            string language = _httpContextAccessor.HttpContext.Request.Headers["Accept-Language"];

            // Example logic to determine language from headers
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Default to English if no language preference is provided
            }

            // Use the language to localize response messages
            string welcomeMessage = _localizer["WelcomeMessage"];
            string goodbyeMessage = _localizer["GoodbyeMessage"];

            return Ok(new { WelcomeMessage = welcomeMessage, GoodbyeMessage = goodbyeMessage });
        }
    }
}
