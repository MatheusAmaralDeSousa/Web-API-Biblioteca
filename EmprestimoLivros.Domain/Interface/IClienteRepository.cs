using EmprestimoLivros.Domain.Modelos;

namespace EmprestimoLivros.Domain.Interface
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Edit(Cliente cliente);
        void Delete(Cliente cliente);
        //Tarefa para selecionar um cliente por ID
        Task<Cliente> GetById(int id);
        //Tarefa para listar todos os clientes
        Task<IEnumerable<Cliente>> GetAll();    
        //Tarefa pra salvar alterações como adicionar, editar, exlcuir
        Task<bool> SaveAllAsync();
    }
}
