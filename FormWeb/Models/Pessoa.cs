using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormWeb.Models
{
    public class Pessoa
    {
        [Key]
        public int idPessoa { get; set; }
        
        public string nome { get; set; }
    
        public string sobrenome { get; set; }
        [DisplayFormat]
        public string cpf { get; set; }
        [DisplayFormat]
        public string cep { get; set; }
        public int IdNacionalidade { get; set; }
        
        public int IdCidade { get; set; }
        
        public int IdEstado { get; set; }

        [ForeignKey("IdNacionalidade")]
        public Nacionalidade nacionalidade { get; set; }

        [ForeignKey("IdEstado")]
        public Estado estado { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade cidade { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Phone]
        public string telefone { get; set; }
        
        public string logradouro { get; set; }

    }
}
