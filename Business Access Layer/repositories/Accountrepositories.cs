using Data_Access_Layer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.models;
using Business_Access_Layer.interfaces;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
namespace Business_Access_Layer.repositories
{
   public class Accountrepositories :  genericrepository<Account>, IAccountrepositories
    {
        public Accountrepositories(datacontext datacontext) : base(datacontext)
        {
        }

       
        public void Delete(Account account)
            => _dbset.Remove(account);

        public async  Task<Account> getaccountbyid(int accountid)
      => await _dbset.FindAsync(accountid);

        public async Task<IEnumerable<Account>> GetAllAccountsAsync(string userid)
           => await _dbset.Where(u => u.UserId == userid).ToListAsync();
        public void update(Account account)
            => _dbset.Update(account);


      
    }
}
