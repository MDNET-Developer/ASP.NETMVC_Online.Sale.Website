using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Musteriler
    {
        [Key]
        public int MusteriID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50 ,ErrorMessage ="Maksimum 50 simvollu verilən daxil edə bilərsiniz !!!")]
        [Required(ErrorMessage ="Boş verilən daxil eliyə bilməzsiniz !!!")]
        public string MusteriAd { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MusteriSoyad { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MusteriSeher { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string MusteriMail { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(25)]
        public string MusteriSifre { get; set; }
        [Column(TypeName = "Nvarchar")]
        [StringLength(155)]
        public string Musterifoto { get; set; }

        public bool Veziyyet { get; set; }
        public ICollection<SatisHereket> SatisHerekets { get; set; }
        public ICollection<KARQO> KARQOs { get; set; }

    }
}