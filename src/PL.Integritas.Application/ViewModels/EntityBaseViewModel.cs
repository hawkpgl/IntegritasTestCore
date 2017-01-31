using System;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Application.ViewModels
{
    public class EntityBaseViewModel
    {
        public EntityBaseViewModel()
        {

        }

        public EntityBaseViewModel(EntityBase entityBase)
        {
            Id = entityBase.Id;
            Active = entityBase.Active;

        }
        #region Properties

        //[Key]
        public Int64 Id { get; set; }

        public Boolean Active { get; set; }

        #endregion
    }
}
