using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class KARQO
    {
        [Key]
        public int KarqoID { get; set; }


      
        [Column(TypeName = "Nvarchar")]
        [StringLength(100)]
        public string Aciqlama { get; set; }


   
        [Column(TypeName = "Nvarchar")]
        [StringLength(10)]
        public string KarqoSERIA { get; set; }


        public int KarqoIsciID { get; set; }
        public virtual KarqoISCILERI KarqoISCILERI { get; set; }


        public int MusteriID { get; set; }
        public virtual Musteriler Musteriler { get; set; }


        [Column(TypeName = "Nvarchar")]
        public string Tarix { get; set; }

     
        public bool YesNo { get; set; }


    }
}