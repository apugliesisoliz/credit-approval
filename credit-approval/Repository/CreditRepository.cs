﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using credit_approval.Models;
using credit_approval.Contracts;

namespace credit_approval.Repository
{
    public class CreditRepository: RepositoryBase<Credit>, ICreditRepository
    {
        public CreditRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Credit> GetAllCredits()
        {
            return FindByCondition(c => c.State == true)
                .OrderBy(c => c.Id)
                .ToList();
        }
        public IEnumerable<Credit> GetByAuthState(int state)
        {
            return FindByCondition(c => c.State == true & c.AuthState == state)
                .OrderBy(c => c.Id)
                .ToList();
        }
        public Credit GetCreditById(int creditId)
        {
            return FindByCondition(c => c.Id == creditId & c.State == true)
                    .FirstOrDefault();
        }
        public bool ClienthasCredits(int clientId)
        {
            return FindByCondition(c => c.ClientId == clientId & c.State == true)
                    .Any();
        }
        public void CreateCredit(Credit credit)
        {
            Create(credit);
        }
        public void UpdateCredit(Credit credit)
        {
            Update(credit);
        }
    }
}
