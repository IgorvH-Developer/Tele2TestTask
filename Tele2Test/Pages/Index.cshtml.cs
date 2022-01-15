using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tele2Test.Services;
using Tele2Test.Models;

namespace Tele2Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileCitizenService citizenService;

        public IEnumerable<Citizen> citizens { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileCitizenService citizenService)
        {
            _logger = logger;
            this.citizenService = citizenService;
        }

        public void OnGet()
        {
            citizens = citizenService.GetCitizens();
        }
    }
}
