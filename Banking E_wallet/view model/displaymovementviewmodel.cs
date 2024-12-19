using Data_Access_Layer.models;
namespace Banking_E_Wallet.view_model
{
    public class displaymovementviewmodel
    {
        public Account account;
        public ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan >();
        public ICollection<withdraw> withdraws { get; set; } = new List<withdraw>();
    }
}
