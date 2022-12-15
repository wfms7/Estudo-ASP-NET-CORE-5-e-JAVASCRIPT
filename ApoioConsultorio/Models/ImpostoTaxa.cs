using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApoioConsultorio.Models
{
    public class ImpostoTaxa
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Column(TypeName = "decimal(4,4)")]
        public decimal imposto_nf { get; set; }

        [Column(TypeName = "decimal(4,4)")]
        public decimal taxa_avista { get; set; }
        [Column(TypeName = "decimal(4,4)")]
        public decimal taxa_Parcelado { get; set; }

        public int ativo { get; set; }

    }
}
