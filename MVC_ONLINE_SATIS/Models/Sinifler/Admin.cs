using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(20)]
        public string IstifadeciAd { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(30)]
        public string Sifre { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(500)]
        public string AdminFoto { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(1)]
        public string Selahiyyet { get; set; }
    }
}