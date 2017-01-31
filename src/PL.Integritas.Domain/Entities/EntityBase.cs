using System;

namespace PL.Integritas.Domain.Entities
{
    public abstract class EntityBase
    {
        #region Properties

        public Int64 Id { get; set; }

        public Boolean Active { get; set; }

        public DateTime? DateRegistered { get; set; }

        public DateTime? DateUpdated { get; set; }

        #endregion
    }
}
