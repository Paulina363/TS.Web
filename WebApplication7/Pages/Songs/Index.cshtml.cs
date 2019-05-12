using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication7.Models.WebApplication7Context _context;

        public IndexModel(WebApplication7.Models.WebApplication7Context context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }

        public async Task OnGetAsync()
        {
            Song = await _context.Song.ToListAsync();
        }
    }
}
