using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListerTechTest.Data.CoreModels
{
    [Table("Wards")]
    public class Ward
    {
        public Ward()
        {
            Spells = new HashSet<Spell>();
        }

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Column("WardId")]
        [Required]
        public int WardId { get; set; }

        [ForeignKey("WardId")]
        public virtual ICollection<Spell> Spells { get; set; }
    }
}
