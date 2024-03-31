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
            var cliente = await _clienteRepository.GetAll();
            var ClienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return Ok(ClienteDTO);
        }
        [HttpPost]
        public async Task<ActionResult> AddClient(Cliente cliente)
        {
            _clienteRepository.Add(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado.");
            }
            return BadRequest("Não foi possível cadastrar o Cliente");
        }

        [HttpPut]
        public async Task<ActionResult> EditClient(Cliente cliente)
        {
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
