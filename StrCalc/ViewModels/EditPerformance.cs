using System.ComponentModel.DataAnnotations;

namespace StrCalc.ViewModels
{
    public class EditPerformance
    {
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
    }
}
