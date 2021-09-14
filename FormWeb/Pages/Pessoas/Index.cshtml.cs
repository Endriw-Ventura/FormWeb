using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormWeb.Models;

namespace FormWeb.Pages.Pessoas
{
    public class IndexModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public IndexModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        public IList<Pessoa> Pessoa { get;set; }

        public async Task OnGetAsync()
        {
            Pessoa = await _context.Pessoa.ToListAsync();
        }
    }
}
