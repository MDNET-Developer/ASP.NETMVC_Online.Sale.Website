using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Karqo_DETALLAR
    {

        [Key]
        public int KarqoDetalID { get; set; }



        [Column(TypeName = "Nvarchar")]
        [StringLength(10)]
        public string KarqoSERIA { get; set; }



        [Column(TypeName = "Nvarchar")]
        public string Hereket { get; set; }

        [Column(TypeName = "Nvarchar")]
        public string Tarix { get; set; }

    }
}