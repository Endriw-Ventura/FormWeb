using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormWeb.Models
{
    public class Nacionalidade
    {
        [Key]
        public int IdPais { get; set; }
        public string Name { get; set; }
        public string Sigla { get; set; }
        public List<Estado> Estados { get; set; }
        public List<Pessoa> Pessoas { get; set; }
    }
}
