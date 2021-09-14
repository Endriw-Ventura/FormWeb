using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormWeb.Models
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string cep { get; set; }
        public string nacionalidade { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string logradouro { get; set; }
    }
}
