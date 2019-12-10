using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F2019Places.Models
{
    public partial class Destination
    {
        public int DestinationId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [StringLength(200)]
        public string Photo { get; set; }
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Destination")]
        public virtual Region Region { get; set; }
    }
}
