using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.models;
namespace Business_Access_Layer.interfaces
{
   public  interface ITransferrepositories :IGenericRepository<Transfer>
    {
     
        Task<IEnumerable<Transfer>> GetTransactionsByAccountIdAsync(int accountId); 
    


    }
}
