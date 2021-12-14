using IECFW.Common.Helper;

using System;

namespace IECFW.Common.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int ActivationStatus { get; set; }
        public virtual ActivationStatusEnum ActivationStatusType { get; set; }
    }

    public class ExtendBaseEntity : BaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
