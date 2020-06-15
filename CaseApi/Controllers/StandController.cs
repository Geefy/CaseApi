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

        [HttpGet]
        public IActionResult GetAllStands()
        {
            try
            {
                var stands = repositoryWrapper.Stand.st();
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
    }
}