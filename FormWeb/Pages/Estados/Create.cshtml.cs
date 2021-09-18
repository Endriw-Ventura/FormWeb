using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Estados
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
        public Estado Estado { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = int.Parse(Request.Form["listaNacionalidades"]);
            Nacionalidade pais = ReturnPais(id);
            Estado.Pais = pais;
            Estado.IdEstadoPais = pais.IdPais;

            _context.Estado.Add(Estado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IEnumerable<SelectListItem> ListaNacionalidades()
        {

            List<SelectListItem> listaView = new List<SelectListItem>();
            List<Nacionalidade> listaPaises = _context.Nacionalidade.OrderBy(e => e.Name).ToList();
            foreach (Nacionalidade pais in listaPaises)
            {
                listaView.Add(new SelectListItem() { Text = pais.Name, Value = pais.IdPais.ToString() });
            }
            return listaView;
        }

        public Nacionalidade ReturnPais(int id)
        {
            Nacionalidade pais = _context.Nacionalidade.Find(id);
            return pais;
        }
    }
}
