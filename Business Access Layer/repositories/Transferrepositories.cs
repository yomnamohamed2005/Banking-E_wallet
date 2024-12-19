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
    internal class Transferrepositories : genericrepository<Transfer>, ITransferrepositories
    {
        public Transferrepositories(datacontext datacontext) : base(datacontext)
        {
        }

        public async Task<IEnumerable<Transfer>> GetTransactionsByAccountIdAsync(int accountId)
         => await _dbset.Where(t => t.FromAccountId == accountId || t.ToAccountId == accountId).ToListAsync();

   
    }
}
