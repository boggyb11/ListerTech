using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListerTechTest.Data.CoreModels
{
    [Table("Spells")]
    public class Spell
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("AdmitDate")]
        [Required]
        public DateTime AdmitDate { get; set; }

        [Column("DischargeDate")]
        public DateTime? DischargeDate { get; set; }

        [Column("Notes")]
        [StringLength(500)]
        public string Notes { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [Required]
        public int WardId { get; set; }

        public virtual Ward Ward { get; set; }

    }
}
