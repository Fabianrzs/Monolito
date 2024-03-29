﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Pages.Note
{
    public class DeleteModel : PageModel
    {
        private readonly WebApi.Data.DbContexts _context;

        public DeleteModel(WebApi.Data.DbContexts context)
        {
            _context = context;
        }

        [BindProperty]
        public WebApi.Models.Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notess.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Notess.FindAsync(id);
            if (note != null)
            {
                Note = note;
                _context.Notess.Remove(Note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
