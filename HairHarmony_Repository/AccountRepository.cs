﻿using HairHarmony_BusinessObject;
using HairHarmony_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairHarmony_Repository
{
    public class AccountRepository : IAccountRepository
    {

        public Account getAccountByID(string id) => AccountDAO.Instance.SearchAccount(id);
        

        public List<Account> getAllAccounts() => AccountDAO.Instance.GetAccountList();

        public bool RegisAccount(Account account) => AccountDAO.Instance.RegisAccount(account);
        
    }
}
