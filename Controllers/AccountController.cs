using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Dtos.Account;
using dotnetEnsekTechChallenge.Models;
using dotnetEnsekTechChallenge.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace dotnetEnsekTechChallenge.Controllers
{
    [ApiController]
    [Route("accountController")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        //Dep injection
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
            
        }
        
        [HttpGet]//only for swagger
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAccountDto>>> GetSingle(int id){
            return Ok(await _accountService.GetAccountById(id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetAccountDto>>>> GetList(){
            return Ok(await _accountService.GetAllAccounts());
        }

        /*
        The data or the adjacent object respectively is sent via the body of
        this request of this request, 
        With the Get(id) we did it via the url
        */

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<Account>>>> AddAccount(AddAccountDto account){
            return Ok(await _accountService.AddAccount(account));
        }
    }
}