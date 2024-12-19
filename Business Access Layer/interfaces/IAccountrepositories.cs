using Data_Access_Layer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.interfaces
{
    public interface IAccountrepositories :IGenericRepository<Account>
    {
       // Task CreateAysnc(Account account);
        void Delete(Account account);
        Task<IEnumerable<Account>> GetAllAccountsAsync(string userid);     
        Task <Account> getaccountbyid(int accountid);
        void update(Account account);
    
    }
}
