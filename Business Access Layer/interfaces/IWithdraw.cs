using Data_Access_Layer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.interfaces
{
  public interface IWithdrawn : IGenericRepository<withdraw>
    {
      
        Task<IEnumerable<withdraw>> GetWithdrawsAsync(int accountid);
      
  
    }
}
