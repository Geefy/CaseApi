using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using EO.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;

namespace CaseApi.Controllers
{
    [Route("api/cases")]
    [ApiController]
    public class CasesController : ControllerBase
    {

        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        private IMapper mapper;

        public CasesController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        //GET: api/cases
        [HttpGet]
        public IActionResult GetAllCases()
        {
            try
            {
                var cases = repositoryWrapper.Cases.GetAllCases();
                logger.LogInfo($"Returned all cases from database");

                var casesResults = mapper.Map<IEnumerable<CasesDTO>>(cases);
                return Ok(casesResults);
            }
            catch (Exception ex)
            {

                logger.LogError($"Something went wrong inside GetAllCases action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        //GET: api/cases/2
        [HttpGet("{caseId}", Name = "CasesById")]
        public IActionResult GetCaseById(int caseId)
        {
            try
            {
                var cases = repositoryWrapper.Cases.GetCaseById(caseId);

                if (cases == null)
                {
                    logger.LogError($"Case with caseId: {caseId}, wasn't found in the database");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"Case with caseId: {caseId}, was found and returned");
                    var caseResult = mapper.Map<CasesDTO>(cases);
                    return Ok(caseResult);
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetCaseById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/cases
        [HttpPost]
        public IActionResult CreateCase([FromBody]CasesForCreationDTO cases)
        {
            try
            {
                if (cases == null)
                {
                    logger.LogError("Cases object sent from client is null");
                    return BadRequest("Cases object is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid cases object sent from client");

                    return BadRequest("Invalid cases object");
                }

                var casesEntity = mapper.Map<Cases>(cases);
                repositoryWrapper.Cases.CreateCase(casesEntity);
                repositoryWrapper.Save();

                var createdCase = mapper.Map<CasesDTO>(casesEntity);

                return CreatedAtAction("CreateCase", createdCase);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside CreatedCase action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        // DELETE: api/cases
        [HttpDelete("{id}", Name = "DeleteCaseById")]
        public IActionResult DeleteCase(int id)
        {
            try
            {

                var caseToDelete = repositoryWrapper.Cases.GetCaseById(id);

                if (caseToDelete == null)
                {
                    logger.LogError("Case object with id " + id + " was not found in the database");
                    return BadRequest("Case object is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid case object sent from client");

                    return BadRequest("Invalid case object");
                }

                repositoryWrapper.Cases.Delete(caseToDelete);
                repositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {

                logger.LogError($"Something went wrong inside DeleteCase method with following error:  { ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //PUT: api/cases
        [HttpPut]
        public IActionResult UpdateCase([FromBody] Cases updatedCase)
        {
            try
            {


                if (updatedCase == null)
                {
                    logger.LogError("Case object is null");
                    return BadRequest("Case object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Case object is invalid");
                }
                repositoryWrapper.Cases.Update(updatedCase);
                repositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside UpdateCaseWithId method with following error:  { ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
