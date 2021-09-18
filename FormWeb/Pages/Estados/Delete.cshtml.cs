using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Estados
{
    public class DeleteModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public DeleteModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Estado Estado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Estado = await _context.Estado.FirstOrDefaultAsync(m => m.IdEstado == id);

            if (Estado == null)
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

            Estado = await _context.Estado.FindAsync(id);

            if (Estado != null)
            {
                _context.Estado.Remove(Estado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
