using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MapDemo.Data
{
    [Serializable]
    public class LocationData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Soldier")]
        public int Soldier_Id { get; set; }

        public SoldierData Soldier { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; } = 550.0;

        public override string ToString()
        {
            return $"Location:{Latitude},{Longitude},{Altitude}";
        }

    }
}
