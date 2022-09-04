using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class KarqoISCILERI
    {
        [Key]
        public int KarqoIsciID { get; set; }



        [Display(Name = "İşçi adı")]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string KarqoIsciAD { get; set; }



        [Display(Name = "İşçi soyadı")]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string KarqoIsciSoyad { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(500)]
        public string KarqoIsciFoto { get; set; }

        [Column(TypeName = "Nvarchar")]
        public string Mail { get; set; }


        [Column(TypeName = "Nvarchar")]
        [StringLength(25)]
        public string Sifre { get; set; }


        public ICollection<KARQO> KARQOs { get; set; }

    }
}