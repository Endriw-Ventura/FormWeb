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
    public class DetailsModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public DetailsModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

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
    }
}
