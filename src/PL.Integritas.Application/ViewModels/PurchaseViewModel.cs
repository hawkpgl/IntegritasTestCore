using System;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Application.ViewModels
{
    public class PurchaseViewModel : EntityBaseViewModel
    {
        public PurchaseViewModel()
        {
            Active = true;
        }

        public PurchaseViewModel(Purchase purchase)
        {
            Id = purchase.Id;
            Active = purchase.Active;
            ShoppingCartId = purchase.ShoppingCartId;
            CardHolderName = purchase.CardHolderName;
            CardNumber = purchase.CardNumber;
            CardExpiryMonth = purchase.CardExpiryMonth;
            CardExpiryYear = purchase.CardExpiryYear;
            CVV = purchase.CVV;
            Adress = purchase.Adress;
            Country = purchase.Country;
            State = purchase.State;
            City = purchase.City;
            ZipPostalCode = purchase.ZipPostalCode;
        }

        #region Properties

        public int CartNumber { get; set; }

        public Int64 ShoppingCartId { get; set; }

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
