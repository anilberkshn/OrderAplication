using System;

namespace Customer.Model.RequestModels
{
    public class SoftDeleteDto
    {
        public DateTime DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}