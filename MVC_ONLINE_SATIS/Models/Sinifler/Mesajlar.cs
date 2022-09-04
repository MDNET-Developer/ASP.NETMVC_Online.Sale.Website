using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }


     
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }

   
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Alici { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(100)]
        public string Basliq { get; set; }

        [Column(TypeName = "Nvarchar(max)")]
        public string Mezmunu { get; set; }


        [Column(TypeName = "Datetime")]
        public DateTime Tarix { get; set; }

        public bool Delete { get; set; }
    }
}