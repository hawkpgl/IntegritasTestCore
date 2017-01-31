using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Application.ViewModels
{
    public class ProductViewModel : EntityBaseViewModel
    {
        public ProductViewModel()
        {
            Active = true;
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Active = product.Active;
            Name = product.Name;
        }

        public int CartNumber { get; set; }

        #region Properties

        public string Name { get; set; }

        #endregion
    }
}
