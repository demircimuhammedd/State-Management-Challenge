using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SMC.Core.Entities.Base;

namespace SMC.Core.Entities
{
    public class Task : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [MaxLength(50)] public string Name { get; set; }

        [MaxLength(500)] public string Description { get; set; }
    }
}