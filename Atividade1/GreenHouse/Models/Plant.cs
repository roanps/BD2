using System;
using System.ComponentModel.DataAnnotations;

namespace Greenhouse.Models
{
    public class Plant
    {
        [Key]
        [StringLength(30)]
        public string Plant_Name { get; set; }

        public float? Sensor_Value { get; set; }

        public DateTime Sensor_Event { get; set; } = DateTime.Now;
    }
}
