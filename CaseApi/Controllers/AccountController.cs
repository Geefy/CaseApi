using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;

namespace CaseApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        private IMapper mapper;

        public AccountController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger, IMapper mapper)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                  var accounts = repositoryWrapper.Account.GetAllAccounts();
                logger.LogInfo("Returned all accounts from database");

                var accountsResult = mapper.Map<IEnumerable<AccountDTO>>(accounts);
                return Ok(accountsResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetAllAccounts actions: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{username}")]
        public IActionResult GetAccountByUsername(string username)
        {
            try
            {
                var account = repositoryWrapper.Account.GetAccountByUsername(username);
                if (account == null)
                {
                    logger.LogError($"Account with username: {username}, wasn't found inside the database");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"Account with username: {username}, was found and returned from the database");

                    var accountResult = mapper.Map<AccountDTO>(account);

                    return Ok(accountResult);
                }

            }
            catch (Exception ex)
            {

                logger.LogError($"Something went wrong inside GetAccountByUsername actions: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}