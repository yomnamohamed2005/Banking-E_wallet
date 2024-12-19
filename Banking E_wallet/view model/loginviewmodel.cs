using Data_Access_Layer.models;
using System.ComponentModel.DataAnnotations;
namespace Banking_E_Wallet.view_model
{
    public class loginviewmodel
    {
        [Required]
    
        [EmailAddress(ErrorMessage = "invalid email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberme { get; set; }

    }
}
