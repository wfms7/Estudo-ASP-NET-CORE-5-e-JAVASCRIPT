using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApoioConsultorio.Models
{
    public class Procedimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ MaxLength(300, ErrorMessage = "Nome não pode exceder 300 caracteres")]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorAvista { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorParcelado { get; set; }

        public string Material_1 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MaterialCustos_1 { get; set; }

        public string Material_2 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MaterialCustos_2 { get; set; }


        public string Material_3 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MaterialCustos_3 { get; set; }


        public string Material_4{ get; set; }

     
        [Column(TypeName = "decimal(10,2)")]
        public decimal MaterialCustos_4 { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        public decimal EquipeCustos1 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal EquipeCustos2 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal EquipeCustos3 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal EquipeCustos4 { get; set; }

        public bool especial { get; set; }

    }
}
