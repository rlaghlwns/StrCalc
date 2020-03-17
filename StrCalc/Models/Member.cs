using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrCalc.Models
{
    public class Member
    {
        [Key]
        public int No { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Pw { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
