using System.Collections.Generic;

namespace PL.Integritas.Domain.Entities
{
    public class ShoppingCart : EntityBase
    {
        public ShoppingCart()
        {
            Active = true;
        }

        public int Number { get; set; }

        #region Properties

        public virtual IEnumerable<ShoppingCartItem> Items { get { return this.items; } }

        #endregion

        #region Fields

        private IList<ShoppingCartItem> items = new List<ShoppingCartItem>();

        #endregion

        #region Methods

        public virtual ShoppingCart AddItem(ShoppingCartItem item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }

            return this;
        }

        public virtual ShoppingCart RemoveItem(ShoppingCartItem item)
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
