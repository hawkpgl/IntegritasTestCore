using PL.Integritas.Infra.Data.Interfaces;
using PL.Integritas.Infra.Data.UoW;

namespace PL.Integritas.Application
{
    public class AppService
    {
        private IUnityOfWork _uow;

        public void BeginTransaction()
        {
            _uow = new UnityOfWork();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
