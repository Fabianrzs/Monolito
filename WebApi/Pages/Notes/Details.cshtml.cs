using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Pages.Note
{
    public class DetailsModel : PageModel
    {
        private readonly WebApi.Data.DbContexts _context;

        public DetailsModel(WebApi.Data.DbContexts context)
        {
            _context = context;
        }

        public WebApi.Models.Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            else
            {
                Note = note;
            }
            return Page();
        }
    }
}
