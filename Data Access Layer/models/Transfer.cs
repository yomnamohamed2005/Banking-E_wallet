using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.models
{
  public class Transfer
    {
        public int TransferId { get; set; } 
        public int ToAccountId { get; set; }
        public int  FromAccountId { get; set; }
        public string type { get; set; }
        public decimal Amount { get; set; } 
        public DateTime TransferDatefrom { get; set; }
        public DateTime TransferDateto { get; set; }
       // public string UserId { get; set; }
       // public user user { get; set; }
        public Account ToAccount { get; set; }
        public Account FromAccount { get; set; }

    }
}
