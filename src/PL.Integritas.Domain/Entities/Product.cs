namespace PL.Integritas.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
            Active = true;
        }

        #region Properties

        public string Name { get; set; }

        #endregion
    }
}
