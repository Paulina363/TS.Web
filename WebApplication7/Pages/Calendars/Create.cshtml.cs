using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models;

namespace WebApplication7.Pages.Calendars
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public CreateModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Calendar Calendar { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Calendar.Add(Calendar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}