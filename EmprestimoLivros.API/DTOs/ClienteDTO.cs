using EmprestimoLivros.API.Modelos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.API.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(150, ErrorMessage ="O nome deve ter, no maximo 150 caracteres.")]
        public string CliNome { get; set; }

        [Required]
        [StringLength(14)]
        [MinLength(14, ErrorMessage = "O CPF deve conter 14 caracteres.")]
        public string CliCPF { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="O endereço deve conter apenas 20 caracteres.")]
        public string CliEndereco { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="A Cidade deve conter apenas 20 caracteres.")]
        public string CliCidade { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "O endereço deve conter apenas 20 caracteres")]
        public string CliBairro { get; set; }


    }
}
