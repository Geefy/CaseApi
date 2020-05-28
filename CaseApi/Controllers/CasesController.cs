using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
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
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{caseId}")]
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
    }
}
