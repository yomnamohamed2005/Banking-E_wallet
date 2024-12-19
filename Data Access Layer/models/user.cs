using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Data_Access_Layer.models
{

public class user : IdentityUser
    {
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
      //  public ICollection<Loan> loans { get; set; } = new List<Loan>();
       // public ICollection<Transfer> transfers { get; set; } = new List<Transfer>();

        public string Pin { get; set; }
        
    }
}
