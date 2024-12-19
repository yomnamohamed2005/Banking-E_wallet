using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.models
{
public class Account
    {
        public int AccountId { get; set; } 
        public string AccountNumber { get; set; } 
        public string AccountHolder { get; set; } 
        public decimal Balance { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public user user { get; set; }
        
        public ICollection<Transfer> FromTransfers { get; set; } = new List<Transfer>();
        public ICollection<Transfer> ToTransfers { get; set; } = new List<Transfer>();
        public ICollection<withdraw> withdraws { get; set; } = new List<withdraw>();
        public ICollection<Loan> loans { get; set; } = new List<Loan>();

    }
}
