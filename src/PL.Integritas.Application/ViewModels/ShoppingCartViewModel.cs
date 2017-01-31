using System.Collections.Generic;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Application.ViewModels
{
    public class ShoppingCartViewModel : EntityBaseViewModel
    {
        public ShoppingCartViewModel()
        {
            Active = true;
        }

        public ShoppingCartViewModel(ShoppingCart shoppingCart)
        {
            Id = shoppingCart.Id;
            Active = shoppingCart.Active;
            Number = shoppingCart.Number;

            foreach (var item in shoppingCart.Items)
            {
                AddItem(new ShoppingCartItemViewModel(item));
            }
        }

        public int Number { get; set; }

        #region Properties

        public virtual IEnumerable<ShoppingCartItemViewModel> ItemsViewModel { get { return this.items; } }

        #endregion

        #region Fields

        private IList<ShoppingCartItemViewModel> items = new List<ShoppingCartItemViewModel>();

        #endregion

        #region Methods

        public virtual ShoppingCartViewModel AddItem(ShoppingCartItemViewModel item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }

            return this;
        }

        public virtual ShoppingCartViewModel RemoveItem(ShoppingCartItemViewModel item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }

            return this;
        }

        #endregion
    }
}
