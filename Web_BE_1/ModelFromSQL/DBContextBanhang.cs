using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_BE_1.ModelFromSQL
{
    public partial class DBContextBanhang : DbContext
    {
        public DBContextBanhang()
        {
        }

        public DBContextBanhang(DbContextOptions<DBContextBanhang> options)
            : base(options)
        {
        }

        public virtual DbSet<TblHanghoa> TblHanghoa1s { get; set; } = null!;
        public virtual DbSet<TblNhomhanghoa> TblNhomhanghoa1s { get; set; } = null!;

    }
}
