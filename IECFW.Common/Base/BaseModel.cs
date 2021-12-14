using System;

namespace IECFW.Common.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public int ActivationStatus { get; set; }
    }
    public class ExtendBaseModel : BaseModel
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
