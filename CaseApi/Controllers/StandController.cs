using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseApi.Controllers
{
    [Route("api/stand")]
    [ApiController]
    public class StandController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        private IMapper mapper;

        public StandController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }


        // GET: api/stand
        [HttpGet]
        public IActionResult GetAllStands()
        {
            try
            {
                var stands = repositoryWrapper.Stand.GetAllStands();
                logger.LogInfo($"Returned all cases from database");

                var standResults = mapper.Map<IEnumerable<StandDTO>>(stands);
                return Ok(standResults);
            }
            catch (Exception ex)
            {

                logger.LogError($"Something went wrong inside GetAllStands action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        //POST: api/stand
        [HttpPost]
        public IActionResult CreateStand([FromBody]StandDTO stand)
        {
            try
            {
                if (stand == null)
                {
                    logger.LogError("Stand object sent from client is null");
                    return BadRequest("Stand object is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid stand object sent from client");

                    return BadRequest("Invalid stand object");
                }

                var standEntity = mapper.Map<Stand>(stand);
                repositoryWrapper.Stand.CreateStand(standEntity);
                repositoryWrapper.Save();

                var createdStand = mapper.Map<StandDTO>(standEntity);

                return CreatedAtAction("CreateStand", createdStand);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside CreateStand action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //DELETE: api/stand/A48
        [HttpDelete("{standName}", Name = "DeleteStandByName")]
        public IActionResult DeleteStand(string standName)
        {
            try
            {

                var stand = repositoryWrapper.Stand.GetStandByName(standName);

                if (stand == null)
                {
                    logger.LogError("Stand object with name " + standName + " was not found in the database");
                    return BadRequest("Stand object is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid stand object sent from client");

                    return BadRequest("Invalid stand object");
                }

                repositoryWrapper.Stand.Delete(stand);
                repositoryWrapper.Save();
                return NoContent();
            }
            catch (Exception ex)
            {

                logger.LogError($"Something went wrong inside DeleteStand action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}