using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("Perfis")]
    public class Perfil
    {
        [Key]
        public int PerfilId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação de senha")]
        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmarSenha { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; }

        //public List<Receita> Receitas { get; set; }
    }
}