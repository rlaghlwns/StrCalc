using System.ComponentModel.DataAnnotations;

namespace StrCalc.ViewModels
{
    public class LoginMember
    {
       
        [Required]
        public string Id { get; set; }
        [Required]
        public string Pw { get; set; }
        

    }
}
