using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Faktura
    {
        [Key]
        public int FakturaID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(3)]
        public string FakturaSeriyaNo { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(10)]
        public string FakturaSiraNo { get; set; }
        public DateTime Tarix { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(100)]
        public string VergiIdaresi { get; set; }
        public DateTime Saat { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Teslimatci { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        public int ToplamMebleg { get; set; }
        public ICollection<FakturaQeyd> FakturaQeyds { get; set; }
    }
}