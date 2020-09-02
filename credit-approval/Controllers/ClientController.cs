using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using credit_approval.Contracts;
using AutoMapper;
using credit_approval.DataTransferObjects;
using credit_approval.Models;

namespace credit_approval.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ClientController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("get")]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _repository.Client.GetAllClients();
                var clientsResult = _mapper.Map<IEnumerable<ClientDto>>(clients);
                return Ok(clientsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/{clientId}", Name = "ClientById")]
        public IActionResult GetClientById(int clientId)
        {
            try
            {
                var client = _repository.Client.GetClientById(clientId);
                if (client == null)
                {
                    return NotFound();
                }
                else
                {
                    var clientResult = _mapper.Map<ClientDto>(client);
                    return Ok(clientResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public IActionResult CreateClient([FromBody] ClientForCreationDto client)
        {
            try
            {
                if (client == null)
                {
                    return BadRequest("client object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var clientEntity = _mapper.Map<Client>(client);
                clientEntity.State = true;
                _repository.Client.CreateClient(clientEntity);
                _repository.Save();
                var createdClient = _mapper.Map<ClientDto>(clientEntity);
                return CreatedAtRoute("ClientById", new { id = createdClient.Id }, createdClient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{Id}")]
        public IActionResult UpdateClient(int Id, [FromBody] ClientForUpdate client)
        {
            try
            {
                if (client == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var clientEntity = _repository.Client.GetClientById(Id);
                if (clientEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(client, clientEntity);
                _repository.Client.UpdateClient(clientEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("delete/{Id}")]
        public IActionResult DeleteClient(int Id)
        {
            try
            {
                var clientEntity = _repository.Client.GetClientById(Id);
                if (clientEntity == null)
                {
                    return NotFound();
                }
                clientEntity.State = false;
                _repository.Client.UpdateClient(clientEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
