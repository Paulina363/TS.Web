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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public DeleteModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calendar = await _context.Calendar.FindAsync(id);

            if (Calendar != null)
            {
                _context.Calendar.Remove(Calendar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
