using EmprestimoLivros.API.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmprestimoLivros.API.Context
{
    public class BibliotecaContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public BibliotecaContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
                options.UseNpgsql(Configuration.GetConnectionString("BibliotecaDB"));
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Livro> Livros { get; set; }

    }
}
