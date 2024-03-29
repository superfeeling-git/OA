﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OA.Entity
{
    /// <summary>
    /// 审计字段
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreateId { get; set; }
        [StringLength(50)]
        public string CreateName { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int? LastModifyId { get; set; }
        [StringLength(50)]
        public string LastModifyName { get; set; }
        public DateTime? LastModifyTime { get; set; }
    }
}
