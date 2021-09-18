using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormWeb.Models
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        public int IdEstadoPais { get; set; }
        public string Name { get; set; }
        public string Sigla { get; set; }
        public List<Cidade> Cidades { get; set; }
        public List<Pessoa> Pessoas { get; set; }

        [ForeignKey("IdEstadoPais")]
        public Nacionalidade Pais { get; set; }
        
    }
}
