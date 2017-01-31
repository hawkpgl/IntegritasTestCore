using System;

namespace PL.Integritas.Domain.Entities
{
    public class Purchase : EntityBase
    {
        public Purchase()
        {
            Active = true;
        }

        #region Properties

        public Int64 ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }
        
        public int CardExpiryMonth { get; set; }

        public int CardExpiryYear { get; set; }

        public string CVV { get; set; }

        public string Adress { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ZipPostalCode { get; set; }

        #endregion
    }
}
