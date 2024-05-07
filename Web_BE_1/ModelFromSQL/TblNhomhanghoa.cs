using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_BE_1.ModelFromSQL
{
    [Table("TblNhomhanghoa1")]
    public partial class TblNhomhanghoa
    {
        public TblNhomhanghoa()
        {
            TblHanghoa1s = new HashSet<TblHanghoa>();
        }

        [Key]
        [Column("NHH_ID")]
        public Guid NhhId { get; set; }
        [Column("NHH_MA")]
        [StringLength(255)]
        public string NhhMa { get; set; } = null!;
        [Column("NHH_TEN")]
        [StringLength(255)]
        public string NhhTen { get; set; } = null!;

        [InverseProperty(nameof(TblHanghoa.HhNhh))]
        public virtual ICollection<TblHanghoa> TblHanghoa1s { get; set; }
    }
}
