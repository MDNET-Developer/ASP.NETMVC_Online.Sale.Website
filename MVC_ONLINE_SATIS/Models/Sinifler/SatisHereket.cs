using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class SatisHereket
    {
        [Key]
        public int SatisID { get; set; }
      
  
        public DateTime Tarix { get; set; }
        public int Eded { get; set; }
        public decimal Qiymet { get; set; }
        public decimal UmumiXerc { get; set; }

        //mehsul
        public int MehsulID { get; set; }
        public virtual Mehsullar Mehsullars { get; set; }

        //musteri
        public int MusteriID { get; set; }
        public virtual Musteriler Musterilers { get; set; }

        //isci
        public int IsciID { get; set; }
        public virtual Isciler Iscilers { get; set; }
    }
}