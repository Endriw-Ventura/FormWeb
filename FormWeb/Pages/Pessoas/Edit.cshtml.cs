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

namespace FormWeb.Pages.Pessoas
{
    public class EditModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public EditModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoa.FirstOrDefaultAsync(m => m.idPessoa == id);

            if (Pessoa == null)
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

            _context.Attach(Pessoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(Pessoa.idPessoa))
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

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.idPessoa == id);
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

