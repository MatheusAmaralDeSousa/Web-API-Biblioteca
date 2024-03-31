using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.Modelos;

public class Emprestimo
{
    public int Id { get; set; }

    public int IdCliente { get; set; }
    public Cliente Cliente { get; set; }

    public int IdLivro { get; set; }
    public Livro Livro { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime DataEmprestimo { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime DataDevolucao { get; set; }


    public Emprestimo(DateTime DataEmprestimo, DateTime DataDevolucao)
    {
        this.DataEmprestimo = DataEmprestimo;
        this.DataDevolucao = DataDevolucao;
    }
}
