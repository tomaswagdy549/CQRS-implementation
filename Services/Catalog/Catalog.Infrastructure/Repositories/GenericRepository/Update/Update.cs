using App.Infrastructure;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.Update
{
    public class Update<T> : IUpdate<T> where T : class
    {
        readonly DbSet<T> _dbSet;
        public Update(ApplicationDbContext ApplicationDbContext)
        {
            _dbSet = ApplicationDbContext.Set<T>();
        }
        T IUpdate<T>.Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
