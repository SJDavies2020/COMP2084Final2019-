using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F2019Places.Models
{
    public partial class Region
    {
        public Region()
        {
            Destination = new HashSet<Destination>();
        }

        public int RegionId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Destination> Destination { get; set; }
    }
}
