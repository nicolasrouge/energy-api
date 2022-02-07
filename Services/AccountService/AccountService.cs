using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetEnsekTechChallenge.Data;
using dotnetEnsekTechChallenge.Dtos.Account;
using dotnetEnsekTechChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetEnsekTechChallenge.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private static List<Account> accountsList = new List<Account>{
            new Account(),
            new Account{AccountId = 1, FirstName = "Nick"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AccountService(IMapper mapper, DataContext dataContext)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> AddAccount(AddAccountDto account)
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
            Account newAccount = _mapper.Map<Account>(account);
            newAccount.AccountId = accountsList.Max( a => a.AccountId) + 1;
            accountsList.Add(newAccount);
            serviceResponse.Data = accountsList.Select(account => _mapper.Map<GetAccountDto>(account)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAccountDto>> GetAccountById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAccountDto>();
            var dbAccount = await _context.Accounts.FirstOrDefaultAsync(c => c.AccountId == id);
            serviceResponse.Data = _mapper.Map<GetAccountDto>(dbAccount);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAccountDto>>> GetAllAccounts()
        {
            var serviceResponse = new ServiceResponse<List<GetAccountDto>>();
            serviceResponse.Data = accountsList.Select(account => _mapper.Map<GetAccountDto>(account)).ToList();
            return serviceResponse;
        }
    }
}