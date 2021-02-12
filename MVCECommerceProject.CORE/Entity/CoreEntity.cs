using MVCECommerceProject.CORE.Enums;
using System;

namespace MVCECommerceProject.CORE.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        public CoreEntity()
        {
            this.Status = Status.Active;
        }

        public Guid ID { get; set; }
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedADUsername { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedADUsername { get; set; }
        public int? ModifiedBy { get; set; }
    }
}