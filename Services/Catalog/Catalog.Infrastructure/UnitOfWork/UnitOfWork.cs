using Catalog.Core.Interfaces.IUnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure;

namespace Catalog.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;
        IDbContextTransaction _currentTransaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            if (_currentTransaction != null)
            {
                await _context.SaveChangesAsync(); // Save before commit
                await _currentTransaction.CommitAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(); // Save before commit
        }
    }
}
