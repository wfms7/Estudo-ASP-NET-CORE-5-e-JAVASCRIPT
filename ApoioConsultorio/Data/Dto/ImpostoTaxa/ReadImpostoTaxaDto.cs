using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApoioConsultorio.Data.Dto.ImpostoTaxa
{
    public class ReadImpostoTaxaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal imposto_nf { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal taxa_avista { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal taxa_Parcelado { get; set; }

        public int ativo { get; set; }

    }
}
