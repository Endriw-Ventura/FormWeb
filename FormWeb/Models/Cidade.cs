using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormWeb.Models
{
    public class Cidade
    {
        [Key]
        public int IdCidade { get; set; }
        public string Name { get; set; }
        public int IdEstadoCidade { get; set; }

        [ForeignKey("IdEstadoCidade")]
        public Estado Estado { get; set; }
        public List<Pessoa> Pessoas { get; set; }
    }
}
