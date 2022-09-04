using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Kateqoriya
    {
        [Key]
        public int KateqoriyaID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string KateqoriyaAd { get; set; }
        public ICollection<Mehsullar> Mehsullars { get; set; }
    }
}