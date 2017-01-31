using System;

namespace PL.Integritas.Domain.Entities
{
    public class ShoppingCartItem : EntityBase
    {
        public ShoppingCartItem()
        {
            Active = true;
        }

        #region Properties

        public Int64 ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Int64 ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        #endregion
    }
}
