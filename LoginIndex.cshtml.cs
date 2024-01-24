using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fitness.Pages
{
    public class LoginIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public LoginIndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
