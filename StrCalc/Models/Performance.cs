using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StrCalc.Models
{
    public class Performance
    {

        [Key]
        public int No { get; set; }
        [ForeignKey("No")]
        public virtual Member Member { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public float Height { get; set; }
        [Required]
        public float Weight { get; set; }

        /// <summary>
        /// Bench Press
        /// </summary>
        [Required]
        public float BP { get; set; }
        /// <summary>
        /// Dead Lift
        /// </summary>
        [Required]
        public float DL { get; set; }
        /// <summary>
        /// Squat
        /// </summary>
        [Required]
        public float SQT { get; set; }
        /// <summary>
        /// BP1rm + DL1rm + SQT1rm
        /// </summary>
        public string Big3Weight { get; set; }
        /// <summary>
        /// Wilk's Point
        /// </summary>
        public float WP { get; set; }
        /// <summary>
        /// Wilk's Rank
        /// </summary>
        public string WR { get; set; }

    }
}
