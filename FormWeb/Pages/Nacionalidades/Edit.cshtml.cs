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

namespace FormWeb.Pages.Nacionalidades
{
    public class EditModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public EditModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nacionalidade Nacionalidade { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nacionalidade = await _context.Nacionalidade.FirstOrDefaultAsync(m => m.IdPais == id);

            if (Nacionalidade == null)
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

            _context.Attach(Nacionalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NacionalidadeExists(Nacionalidade.IdPais))
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

        private bool NacionalidadeExists(int id)
        {
            return _context.Nacionalidade.Any(e => e.IdPais == id);
        }
    }
}
