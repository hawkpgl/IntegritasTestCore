using System;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Application.ViewModels
{
    public class ShoppingCartItemViewModel : EntityBaseViewModel
    {
        public ShoppingCartItemViewModel()
        {
            Active = true;
        }

        public ShoppingCartItemViewModel(ShoppingCartItem shoppingCartItem)
        {
            Id = shoppingCartItem.Id;
            Active = shoppingCartItem.Active;
            ProductId = shoppingCartItem.ProductId;
            ShoppingCartId = shoppingCartItem.ShoppingCartId;
        }

        #region Properties

        public Int64 ProductId { get; set; }

        public string Name { get; set; }

        public Int64 ShoppingCartId { get; set; }

        #endregion
    }
}
