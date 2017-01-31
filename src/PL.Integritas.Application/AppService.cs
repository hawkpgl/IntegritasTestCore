using PL.Integritas.Infra.Data.Interfaces;
using PL.Integritas.Infra.Data.UoW;

namespace PL.Integritas.Application
{
    public class AppService
    {
        private IUnityOfWork _uow;

        public AppService(IUnityOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
