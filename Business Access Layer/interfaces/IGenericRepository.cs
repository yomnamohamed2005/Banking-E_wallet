using Data_Access_Layer.models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.interfaces
{
   public  interface IGenericRepository<TEntity>
    {
        Task CreateAsync(TEntity entity);
        Task<int> SaveChangesasync();

      //  Task<IEnumerable<TEntity>> GetAllAsync(int accountid);

    }
}
