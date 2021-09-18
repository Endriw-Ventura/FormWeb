using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Nacionalidades
{
    public class DetailsModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public DetailsModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

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
    }
}
