using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Mehsullar
    {
        [Key]
        public int MehsulID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MehsulAd { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisQiymet { get; set; }
        public decimal SatisQiymet { get; set; }
        public bool Veziyyet { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(500)]
        public string MehsulFoto { get; set; }
        public int KateqoriyaID { get; set; }
        public virtual Kateqoriya Kateqoriya { get; set; }
        public ICollection<SatisHereket> SatisHerekets { get; set; }
    }
}