using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.Modelos;

public class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Required]
    [Column("CliNome")]
    [StringLength(150)]
    public string CliNome { get; set; }

    [Required]
    [Column("CliCPF")]
    [StringLength(14)]
    public string CliCPF { get; set; }

    [Required]
    [Column("CliEndereco")]
    [StringLength (20)]
    public string CliEndereco { get; set; }

    [Required]
    [Column("CliCidade")]
    [StringLength (20)]
    public string CliCidade { get; set; }
    [Required]
    [Column("CliBairro")]
    [StringLength(20)]
    public string CliBairro { get; set; }

    public List<Emprestimo>? Emprestimos { get; set; }

    public Cliente(string CliNome, string CliCPF, string CliEndereco, string CliCidade, string CliBairro)
    {
        this.CliNome = CliNome;
        this.CliCPF = CliCPF;
        this.CliEndereco = CliEndereco;
        this.CliCidade = CliCidade;
        this.CliBairro = CliBairro;
    }  


}
