using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Nacionalidades
{
    public class CreateModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public CreateModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nacionalidade Nacionalidade { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Nacionalidade.Add(Nacionalidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
