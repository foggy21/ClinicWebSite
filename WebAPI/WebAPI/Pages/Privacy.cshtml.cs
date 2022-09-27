using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace WebAPI.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("ru-RU"));
            ViewData["TimeStamp"] = dateTime;
        }
    }
}