using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BasicCodeFirstApproachCrudOperations.Models.Wine
{
    public class Wine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Guuid")]
        public Guid uuid { get; set; }
        public int Id { get; set; }
        public string ?Name { get; set; }
        public int Years { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

    }
}
