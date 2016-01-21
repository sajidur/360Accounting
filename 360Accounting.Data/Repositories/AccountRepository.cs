﻿using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Accounting.Data.Repositories
{
    public class AccountRepository : Repository, IAccountRepository
    {
        public Account GetAccountBySOBId(string sobId)
        {
            Account account = this.GetAll()
                .FirstOrDefault(x => x.SOBId == Convert.ToInt32(sobId));
            return account;
        }

        public Account GetSingle(string id)
        {
            Account account = this.GetAll()
                .FirstOrDefault(x => x.Id == Convert.ToInt32(id));
            return account;
        }

        public IEnumerable<Account> GetAll()
        {
            IEnumerable<Account> accountList = this.Context.Accounts;
            return accountList;
        }

        public string Insert(Account entity)
        {
            this.Context.Accounts.Add(entity);
            this.Commit();
            return entity.Id.ToString();
        }

        public string Update(Account entity)
        {
            this.Context.Accounts.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Commit();
            return entity.Id.ToString();
        }

        public void Delete(string id)
        {
            this.Context.Accounts.Remove(this.GetSingle(id));
            this.Commit();
        }

        public int Count()
        {
            return this.GetAll().Count();
        }

        public int Commit()
        {
            return this.Context.SaveChanges();
        }
    }
}