using System;

namespace OA.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreateId { get; set; }
        public DateTime CreateTime { get; set; }
        public int? LastModifyId { get; set; }
        public DateTime? LastModifyTime { get; set; }
    }
}
