using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Cidades
{
    public class DeleteModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public DeleteModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cidade Cidade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cidade = await _context.Cidade.FirstOrDefaultAsync(m => m.IdCidade == id);

            if (Cidade == null)
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

            Cidade = await _context.Cidade.FindAsync(id);

            if (Cidade != null)
            {
                _context.Cidade.Remove(Cidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
