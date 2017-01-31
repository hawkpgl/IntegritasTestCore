using PL.Integritas.Infra.Data.Context;
using PL.Integritas.Infra.Data.Interfaces;
using System;

namespace PL.Integritas.Infra.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly IntegritasContext _dbContext;
        private bool _disposed;

        public UnityOfWork()
        {
            var contextManager = new ContextManager();
            _dbContext = contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

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
    }
}
