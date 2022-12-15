using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApoioConsultorio.Data.Dto.ImpostoTaxa
{
    public class UpdateImpostotaxaDto
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public decimal imposto_nf { get; set; }

        public decimal taxa_avista { get; set; }

        public decimal taxa_Parcelado { get; set; }

        public int ativo { get; set; }
    }
}
