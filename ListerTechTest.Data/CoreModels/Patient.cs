using ListerTechTest.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListerTechTest.Data.CoreModels
{
    [Table("Patients")]
    public class Patient
    {
        public Patient()
        {
            Spells = new HashSet<Spell>();
        }

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [Column("DateOfBirth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column("Gender")]
        [Required]
        [StringLength(1)]
        public Gender Gender { get; set; }

        [ForeignKey("PatientId")]
        public virtual ICollection<Spell> Spells { get; set; }
    }
}
