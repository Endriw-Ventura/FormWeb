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
    public class IndexModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public IndexModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        public IList<Nacionalidade> Nacionalidade { get;set; }

        public async Task OnGetAsync()
        {
            Nacionalidade = await _context.Nacionalidade.ToListAsync();
        }
    }
}
