using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Domain.Interface;
using EmprestimoLivros.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BibliotecaContext _context;

        public ClienteRepository(BibliotecaContext context)
        {
            _context = context;
        }
        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }
        public void Edit(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }
        public void Delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }
        public async Task<Cliente> GetById(int id)
        {
            //await e usado para a tarefa aguarda e conseguir retornar o cliente
            var cliente = await _context.Clientes.SingleOrDefaultAsync(x => x.IdCliente == id);
            return cliente;
        }
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            //Se for maior que 0, signifca que salvou corretamente.
            //Caso contrário ele retornará com um erro(Erro de banco, não salva no banco).
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
