using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using credit_approval.DataTransferObjects;
using credit_approval.Models;
using credit_approval.Contracts;


namespace credit_approval.Controllers
{
    [Route("api/credit")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public CreditController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("get")]
        public IActionResult GetAllCredits()
        {
            try
            {
                var credits = _repository.Credit.GetAllCredits();
                var creditsResult = _mapper.Map<IEnumerable<CreditDto>>(credits);
                return Ok(creditsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/{creditId}", Name = "CreditById")]
        public IActionResult GetCreditById(int creditId)
        {
            try
            {
                var credit = _repository.Credit.GetCreditById(creditId);
                if (credit == null)
                {
                    return NotFound();
                }
                else
                {
                    var creditResult = _mapper.Map<CreditDto>(credit);
                    return Ok(creditResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getByAuthState/{state}")]
        public IActionResult GetByAuthState(int state)
        {
            try
            {
                var credits = _repository.Credit.GetByAuthState(state);
                var creditsResult = _mapper.Map<IEnumerable<CreditDto>>(credits);
                return Ok(creditsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public IActionResult CreateCredit([FromBody] CreditForCreationDto credit)
        {
            try
            {
                if (credit == null)
                {
                    return BadRequest("client object is null");
                }
                if (!_repository.Client.ClientExist(credit.ClientId)) 
                {
                    return BadRequest("client dont exist");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var CreditEntity = _mapper.Map<Credit>(credit);
                CreditEntity.State = true;
                CreditEntity.AuthState = 0; //creado no evaluado
                CreditEntity.DateRequest = DateTime.Now;
                _repository.Credit.CreateCredit(CreditEntity);
                _repository.Save();
                var createdCredit = _mapper.Map<CreditDto>(CreditEntity);
                return CreatedAtRoute("CreditById", new { creditId = createdCredit.Id }, createdCredit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{Id}")]
        public IActionResult UpdateCredit(int Id, [FromBody] CreditForUpdate credit)
        {
            try
            {
                if (credit == null)
                {
                    return BadRequest("Credit object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var creditEntity = _repository.Credit.GetCreditById(Id);
                if (creditEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(credit, creditEntity);
                _repository.Credit.UpdateCredit(creditEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("approve/{Id}")]
        public IActionResult ApproveCredit(int Id, [FromBody] CreditForApproveDto credit)
        {
            try
            {
                if (credit == null)
                {
                    return BadRequest("Credit object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var creditEntity = _repository.Credit.GetCreditById(Id);
                if (creditEntity == null)
                {
                    return NotFound();
                }
                if (!_repository.User.UserHasPrivileges(credit.UserAuth))
                {
                    return BadRequest("Cant approve a credit, user has no privileges");
                }
                _mapper.Map(credit, creditEntity);
                creditEntity.DateAuth = DateTime.Now;
                creditEntity.AuthState = 1; // 1 is approved
                _repository.Credit.UpdateCredit(creditEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("refuse/{Id}")]
        public IActionResult RefuseCredit(int Id, [FromBody] CreditForApproveDto credit)
        {
            try
            {
                if (credit == null)
                {
                    return BadRequest("Credit object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var creditEntity = _repository.Credit.GetCreditById(Id);
                if (creditEntity == null)
                {
                    return NotFound();
                }
                if (!_repository.User.UserHasPrivileges(credit.UserAuth))
                {
                    return BadRequest("Cant approve a credit, user has no privileges");
                }
                _mapper.Map(credit, creditEntity);
                creditEntity.DateAuth = DateTime.Now;
                creditEntity.AuthState = 2; // 2 is refused
                _repository.Credit.UpdateCredit(creditEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("delete/{Id}")]
        public IActionResult DeleteCredit(int Id)
        {
            try
            {
                var creditEntity = _repository.Credit.GetCreditById(Id);
                if (creditEntity == null)
                {
                    return NotFound();
                }
                creditEntity.State = false;
                _repository.Credit.UpdateCredit(creditEntity);
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
