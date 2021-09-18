using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormWeb.Data;
using FormWeb.Models;

namespace FormWeb.Pages.Pessoas
{
    public class DetailsModel : PageModel
    {
        private readonly FormWeb.Data.FormWebContext _context;

        public DetailsModel(FormWeb.Data.FormWebContext context)
        {
            _context = context;
        }

        public Pessoa Pessoa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoa.FirstOrDefaultAsync(m => m.idPessoa == id);

            Cidade cidade = ReturnCidade(Pessoa.IdCidade);
            Estado estado = ReturnEstado(Pessoa.IdEstado);
            Nacionalidade pais = ReturnNacionalidade(Pessoa.IdNacionalidade);

            Pessoa.estado = estado;
            Pessoa.cidade = cidade;
            Pessoa.nacionalidade = pais;


            if (Pessoa == null)
            {
                return NotFound();
            }
            return Page();
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
