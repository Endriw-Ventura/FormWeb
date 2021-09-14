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
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string sobrenome { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string cpf { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string cep { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string nacionalidade { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string estado { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string cidade { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string email { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "Favor Preencher todos os campos")]
        public string logradouro { get; set; }

    }
}
