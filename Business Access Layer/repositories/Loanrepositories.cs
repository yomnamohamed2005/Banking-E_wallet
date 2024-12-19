using Business_Access_Layer.interfaces;
using Data_Access_Layer.Data;
using Data_Access_Layer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.repositories
{
    public class Loanrepositories : genericrepository<Loan>, ILoanrepositories
    {
        public Loanrepositories(datacontext datacontext) : base(datacontext)
        {
        }

        public async Task<IEnumerable<Loan>> GetLoansByAccountIdAsync(int accountid)
         => await _dbset.Where(l => l.AccountId== accountid).ToListAsync();
    }
}
