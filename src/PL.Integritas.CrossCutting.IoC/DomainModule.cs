using Ninject.Modules;
using PL.Integritas.Domain.Interfaces.Services;
using PL.Integritas.Domain.Services;

namespace PL.Integritas.CrossCutting.IoC
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<Interface>().To<Concrete>();
            Bind<IProductService>().To<ProductService>();
            Bind<IPurchaseService>().To<PurchaseService>();
            Bind<IShoppingCartService>().To<ShoppingCartService>();
            Bind<IShoppingCartItemService>().To<ShoppingCartItemService>();
        }
    }
}
