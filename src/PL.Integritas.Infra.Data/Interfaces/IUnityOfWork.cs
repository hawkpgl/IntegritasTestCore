using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Integritas.Infra.Data.Interfaces
{
    public interface IUnityOfWork
    {
        void BeginTransaction();

        void SaveChanges();
    }
}
