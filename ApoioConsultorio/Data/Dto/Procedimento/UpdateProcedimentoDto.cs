using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApoioConsultorio.Data.Dto.Procedimento
{
    public class UpdateProcedimentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorAvista { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorParcelado { get; set; }

        public string Material_1 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MaterialCustos_1 { get; set; }

        public string Material_2 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MaterialCustos_2 { get; set; }


        public string Material_3 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MaterialCustos_3 { get; set; }


        public string Material_4 { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MaterialCustos_4 { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal EquipeCustos1 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal EquipeCustos2 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal EquipeCustos3 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal EquipeCustos4 { get; set; }

        public bool especial { get; set; }
    }
}
