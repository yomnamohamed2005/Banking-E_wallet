using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.models
{
    public  class Loan
    {
        public int LoanId { get; set; } // المعرف الفريد للقرض
         
        public decimal LoanAmount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account account { get; set; }
    }
}
