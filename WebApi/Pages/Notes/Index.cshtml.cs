using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Pages.Note
{
    public class IndexModel : PageModel
    {
        private readonly WebApi.Data.DbContexts _context;

        public IndexModel(WebApi.Data.DbContexts context)
        {
            _context = context;
        }

        public IList<WebApi.Models.Note> Note { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Note = await _context.Notes.ToListAsync();
        }
    }
}
