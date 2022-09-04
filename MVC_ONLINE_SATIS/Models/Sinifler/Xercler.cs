using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ONLINE_SATIS.Models.Sinifler
{
    public class Xercler
    {
        [Key]
        public int XerclerID { get; set; }

        [Column(TypeName = "Nvarchar")]
        [StringLength(100)]
        public string Aciqlama { get; set; }
        public DateTime Tarix { get; set; }
        public decimal UmumiXerc { get; set; }
    }
}