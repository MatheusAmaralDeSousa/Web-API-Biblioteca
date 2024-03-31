using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.Modelos;

public partial class Livro
{
    [Key]
    [Column("id_livro")]
    public int IdLivro { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(150)]
    public string LivroNome { get; set; }
    
    [Required]
    [Column("autor")]
    [StringLength (150)]
    public string LivroAutor { get; set; }

    [Required]
    [Column("editora")]
    [StringLength (150)]
    public string LivroEditora { get; set; }

    [Column("disponivel")]
    public bool Disponivel { get; set; }

    public List<Emprestimo> Emprestimos { get; set; }

    public Livro(string livroNome, string livroAutor, string livroEditora, bool disponivel)
    {
        this.LivroNome = livroNome;
        this.LivroAutor = livroAutor;
        this.LivroEditora = livroEditora;
        this.Disponivel = disponivel;
    }
    
}
