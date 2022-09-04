using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Isciler
    {
        [Key]
        public int IsciID { get; set; }
        [Display(Name ="İşçi adı")]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string IsciAd { get; set; }

        [Display(Name = "İşçi soyadı")]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string IsciSoyad { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(500)]
        public string IsciFoto { get; set; }
        public ICollection<SatisHereket> SatisHerekets { get; set; }
        public int SobeID { get; set; }
        public virtual  Sobeler Sobeler { get; set; }
    }
}