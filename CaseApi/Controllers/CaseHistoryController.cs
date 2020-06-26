using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseApi.Controllers
{
    [Route("api/casehistory")]
    [ApiController]
    public class CaseHistoryController : ControllerBase
    {
        IMapper mapper;
        ILoggerManager logger;
        IRepositoryWrapper repositoryWrapper;
        public CaseHistoryController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger, IMapper mapper)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;

        }
        //GET: api/casehistory/{standName}
        [HttpGet("{standName}", Name = "CaseHistoryByStand")]
        public IActionResult GetCaseHistoryByStand(string standName)
        {
            try
            {
                var cases = repositoryWrapper.CaseHistory.GetCaseHistoriesByStand(standName);
                if (cases == null)
                {
                    logger.LogError($"CaseHistories with stand name: {standName}, wasn't found in the database");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"CaseHistories with stand name: {standName}, was found and returned");
                    var caseHResult = mapper.Map<IEnumerable<CaseHistoryDTO>>(cases);
                    return Ok(caseHResult);
                }

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetCaseHistoryByStand action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}