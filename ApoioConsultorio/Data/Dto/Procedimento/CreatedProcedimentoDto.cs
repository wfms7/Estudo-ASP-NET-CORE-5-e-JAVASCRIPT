using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApoioConsultorio.Data.Dto.Procedimento
{
    public class CreatedProcedimentoDto

    {
      
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorAvista { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorParcelado { get; set; }

        public string Material_1 { get; set; }

       
        public decimal MaterialCustos_1 { get; set; }

        public string Material_2 { get; set; }

       
        public decimal MaterialCustos_2 { get; set; }


        public string Material_3 { get; set; }

       
        public decimal MaterialCustos_3 { get; set; }


        public string Material_4 { get; set; }


       
        public decimal MaterialCustos_4 { get; set; }


     
        public decimal EquipeCustos1 { get; set; }

        public decimal EquipeCustos2 { get; set; }


        public decimal EquipeCustos3 { get; set; }

  
        public decimal EquipeCustos4 { get; set; }

        public bool especial { get; set; }
    }
}
