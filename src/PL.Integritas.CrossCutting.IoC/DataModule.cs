using Ninject.Modules;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Infra.Data.Context;
using PL.Integritas.Infra.Data.Interfaces;
using PL.Integritas.Infra.Data.Repository;
using PL.Integritas.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Integritas.CrossCutting.IoC
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<Interface>().To<Concrete>();
            Bind<IUnityOfWork>().To<UnityOfWork>();
            Bind<IContextManager>().To<ContextManager>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IPurchaseRepository>().To<PurchaseRepository>();
            Bind<IShoppingCartRepository>().To<ShoppingCartRepository>();
            Bind<IShoppingCartItemRepository>().To<ShoppingCartItemRepository>();
        }
    }
}
