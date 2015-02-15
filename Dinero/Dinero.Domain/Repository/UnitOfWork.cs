using Dinero.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinero.Domain.Repository
{
    public class UnitOfWork : IDisposable
    {

        #region "Members"

        private readonly DineroDbContext _dbContext;

        private UserRepository _userRepository;


        #endregion

        public UnitOfWork()
        {
            _dbContext = new DineroDbContext();
        }

        #region "Properties"

        public UserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_dbContext)); }
        }

        #endregion


        #region "Methods"

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #endregion


        #region "IDisposible"

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
