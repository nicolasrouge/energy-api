using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Dtos.Account;
using dotnetEnsekTechChallenge.Models;

namespace dotnetEnsekTechChallenge.Services.AccountService
{
    public interface IAccountService
    {
        Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts();
        Task<ServiceResponse<GetAccountDto>> GetAccountById(int id);
        Task<ServiceResponse<List<GetAccountDto>>> AddAccount(AddAccountDto account);
    }
}