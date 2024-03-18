using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapDemo.Data
{
    [Serializable]
    public class SoldierData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public virtual ICollection<LocationData> Locations { get; set; } = new List<LocationData>();

        public SoldierData()
        {
            Name = "Name" + Id;
            Rank = "Rank" + Id;
        }
    }
}
