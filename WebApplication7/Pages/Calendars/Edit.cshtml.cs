using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Pages.Calendars
{
    public class EditModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public EditModel(WebApplication7.Models.WebApplication7Context context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Calendar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarExists(Calendar.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CalendarExists(int id)
        {
            return _context.Calendar.Any(e => e.ID == id);
        }
    }
}
