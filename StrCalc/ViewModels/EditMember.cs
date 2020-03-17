using System.ComponentModel.DataAnnotations;

namespace StrCalc.ViewModels
{
    public class EditMember
    {

        [Required]
        public string Pw { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
