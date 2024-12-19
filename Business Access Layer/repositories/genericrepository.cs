using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Business_Access_Layer.interfaces;
using Data_Access_Layer.Data;
using Data_Access_Layer.models;
using Microsoft.EntityFrameworkCore;
namespace Business_Access_Layer.repositories
{
    public class genericrepository<TEntity> :IGenericRepository<TEntity> where TEntity :class 
    {
        private datacontext _datacontect;
        protected DbSet<TEntity> _dbset;
        public genericrepository(datacontext datacontext)
        {
            _datacontect = datacontext;
            _dbset = datacontext.Set<TEntity>();
        }
    
        public async Task CreateAsync(TEntity entity)
            => await _dbset.AddAsync(entity);
        public async Task<int> SaveChangesasync() => await _datacontect.SaveChangesAsync(); 

    }
}

