using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Pages.Calendars
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public DetailsModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        public Calendar Calendar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calendar = await _context.Calendar.FirstOrDefaultAsync(m => m.ID == id);

            if (Calendar == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
