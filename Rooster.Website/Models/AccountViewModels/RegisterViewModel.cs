using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Rooster.Website.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare("ConfirmEmailAddress")]
        public string ConfirmEmailAddress { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        [Compare("ConfirmEmailAddress")]
        public string ConfirmPassword { get; set; }
    }
}