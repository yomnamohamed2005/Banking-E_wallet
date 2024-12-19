using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.models
{
    public class withdraw
    {
            public int Id { get; set; }
            public int AccountId { get; set; }
            public Account Account { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
       
    }
}
