using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_BE_1.ModelFromSQL
{
    [Table("tblHanghoa1")]
    public partial class TblHanghoa
    {
        [Key]
        [Column("HH_ID")]
        public Guid HhId { get; set; }
        [Column("HH_NHH_ID")]
        public Guid? HhNhhId { get; set; }
        [Column("HH_MA")]
        [StringLength(255)]
        public string HhMa { get; set; } = null!;
        [Column("HH_TEN")]
        [StringLength(255)]
        public string HhTen { get; set; } = null!;
        [Column("HH_GIANHAP", TypeName = "decimal(10, 2)")]
        public decimal HhGianhap { get; set; }
        [Column("HH_GIABAN", TypeName = "decimal(10, 2)")]
        public decimal HhGiaban { get; set; }

        [ForeignKey(nameof(HhNhhId))]
        [InverseProperty(nameof(TblNhomhanghoa.TblHanghoa1s))]
        public virtual TblNhomhanghoa? HhNhh { get; set; }
    }
}
