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
        [StringLength(150)]
        public string CliNome { get; set; }

        [Required]
        [StringLength(14)]
        [MinLength(14)]
        public string CliCPF { get; set; }

    }
}
