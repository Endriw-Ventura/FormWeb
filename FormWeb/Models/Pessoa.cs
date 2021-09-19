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
        [Required(ErrorMessage = "Campo obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string sobrenome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string cpf { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
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

        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string email { get; set; }

        [Phone]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string logradouro { get; set; }

    }
}
