using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Pessoas
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
        public Pessoa Pessoa { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int idPais = int.Parse(Request.Form["listaNacionalidades"]);
            int idEstado = int.Parse(Request.Form["listaEstados"]);
            int idCidade = int.Parse(Request.Form["listaCidades"]);

            Cidade cidade = ReturnCidade(idCidade);
            Estado estado = ReturnEstado(idEstado);
            Nacionalidade pais = ReturnNacionalidade(idPais);

            Pessoa.cidade = cidade;
            Pessoa.IdCidade = cidade.IdCidade;
            Pessoa.estado = estado;
            Pessoa.IdEstado = estado.IdEstado;
            Pessoa.nacionalidade = pais;
            Pessoa.IdNacionalidade = pais.IdPais; 

            _context.Pessoa.Add(Pessoa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IEnumerable<SelectListItem> ListaPaises()
        {

            List<SelectListItem> listaView = new List<SelectListItem>();
            List<Nacionalidade> listaPaises = _context.Nacionalidade.ToList();
            foreach (Nacionalidade pais in listaPaises)
            {

                listaView.Add(new SelectListItem() { Text = pais.Name, Value = pais.IdPais.ToString() });
               
            }
            return listaView;
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

        public IEnumerable<SelectListItem> ListaCidades()
        {

            List<SelectListItem> listaView = new List<SelectListItem>();
            List<Cidade> listaCidades = _context.Cidade.OrderBy(e => e.Name).ToList();
            foreach (Cidade cidade in listaCidades)
            {

                listaView.Add(new SelectListItem() { Text = cidade.Name, Value = cidade.IdCidade.ToString() });

            }
            return listaView;
        }

        public Estado ReturnEstado(int id)
        {
            Estado estado = _context.Estado.Find(id);
            return estado;
        }

        public Nacionalidade ReturnNacionalidade(int id)
        {
            Nacionalidade pais = _context.Nacionalidade.Find(id);
            return pais;
        }

        public Cidade ReturnCidade(int id)
        {
            Cidade cidade = _context.Cidade.Find(id);
            return cidade;
        }
    }
}
