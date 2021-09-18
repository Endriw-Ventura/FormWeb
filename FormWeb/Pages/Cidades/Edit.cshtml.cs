using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Cidades
{
    public class EditModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public EditModel(FormWeb.Data.FormWebContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(Cidade.IdCidade))
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

        private bool CidadeExists(int id)
        {
            return _context.Cidade.Any(e => e.IdCidade == id);
        }
    }
}
