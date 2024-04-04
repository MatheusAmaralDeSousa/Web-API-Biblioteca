using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Interface;
using EmprestimoLivros.API.Modelos;
using EmprestimoLivros.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        //Importa o mapper
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.GetAll();
            var ClientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);

            return Ok(ClientesDTO);
        }
        [HttpPost]
        public async Task<ActionResult> AddClient(ClienteDTO clienteDTO)
        {
            //Mapeamento inverso, mapeia de ClienteDTO para Cliente
            var cliente =  _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Add(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado.");
            }
            return BadRequest("Não foi possível cadastrar o Cliente");
        }

        [HttpPut]
        public async Task<ActionResult> EditClient(ClienteDTO clienteDTO)
        {
            if (clienteDTO.IdCliente == 0)
            {
                return BadRequest("Não é possivel alterar o cliente. É preciso informar o ID");
            }

            var clienteExiste = await _clienteRepository.GetById(clienteDTO.IdCliente);

            if(clienteExiste == null)
            {
                return NotFound("Cliente não encontrado");
            }
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Edit(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Dados alterados com sucesso.");
            }
            return BadRequest("Não foi possivel concluir a operação.");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var cliente = await _clienteRepository.GetById(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            _clienteRepository.Delete(cliente);

            if(await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente deletado com Sucesso.");
            }

            return BadRequest("Não foi possível concluir a operação.");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClient(int id)
        {
            var cliente = await _clienteRepository.GetById(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            //Passa o destino, pra onde as informações serão passadas, no caso ClienteDTO 
            //E qual objeto será mapeado, no caso cliente
            var ClienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return Ok(ClienteDTO);
        }
    }
}
