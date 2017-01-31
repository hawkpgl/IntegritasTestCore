using Ninject.Modules;
using PL.Integritas.Application;
using PL.Integritas.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Integritas.CrossCutting.IoC
{
    public class AppModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<Interface>().To<Concrete>();
            Bind<IProductAppService>().To<ProductAppService>();
            Bind<IPurchaseAppService>().To<PurchaseAppService>();
            Bind<IShoppingCartAppService>().To<ShoppingCartAppService>();
        }
    }
}
