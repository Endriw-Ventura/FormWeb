using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Cidades
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
        public Cidade Cidade { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int id = int.Parse(Request.Form["listaEstados"]);
            Estado estado = ReturnEstado(id);
            Cidade.Estado = estado;
            Cidade.IdEstadoCidade = estado.IdEstado;

            _context.Cidade.Add(Cidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IEnumerable<SelectListItem> ListaEstados()
        {

            List<SelectListItem> listaView = new List<SelectListItem>();
            List<Estado> listaEstados = _context.Estado.OrderBy(e => e.Name).ToList();
            foreach (Estado estado in listaEstados)
            {
                listaView.Add(new SelectListItem() { Text = estado.Name, Value = estado.IdEstado.ToString() });
            }
            return listaView;
        }

        public Estado ReturnEstado(int id)
        {
            Estado estado = _context.Estado.Find(id);
            return estado;
        }
    }
}
