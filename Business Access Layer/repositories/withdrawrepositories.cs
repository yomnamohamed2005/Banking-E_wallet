using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Access_Layer.interfaces;
using Data_Access_Layer.Data;
using Data_Access_Layer.models;
using Microsoft.EntityFrameworkCore;
namespace Business_Access_Layer.repositories
{
    public class withdrawrepositories : genericrepository<withdraw>, IWithdrawn
    {
        public withdrawrepositories(datacontext datacontext) : base(datacontext)
        {
        }

        public async Task<IEnumerable<withdraw>> GetWithdrawsAsync(int accountid)
         => await _dbset.Where(w => w.AccountId == accountid).ToListAsync();
    }
}
