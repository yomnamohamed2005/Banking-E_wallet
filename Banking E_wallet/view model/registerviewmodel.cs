using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.models;
namespace Banking_E_Wallet.view_model
{
    public class registerviewmodel
    {
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(password), ErrorMessage = "password or confirmpassword not match")]
        public string confirmationpassword { get; set; }
      

    }
}
