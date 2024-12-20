using Banking_E_Wallet.view_model;
using Business_Access_Layer.interfaces;
using Data_Access_Layer.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Identity.Client;
using static Banking_E_Wallet.Controllers.accountcontroller;

namespace Banking_E_Wallet.Controllers 
{
    public class accountcontroller : Controller
    {
        private readonly IAccountrepositories _account;
        private readonly IWithdrawn _withdraw;
        private readonly ITransferrepositories _transfer;
        private readonly ILoanrepositories _loan;
        public accountcontroller(IAccountrepositories account, IWithdrawn withdraw , ITransferrepositories transfer, ILoanrepositories loan )
        {
            _account = account;
            _withdraw = withdraw;
            _transfer = transfer;
            _loan = loan;
        }
        public ActionResult withdraw()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Withdraw(decimal amount, int ? accountid)
        {
            if (!accountid.HasValue) return BadRequest();
            var curraccount = await _account.getaccountbyid(accountid.Value);
            if (curraccount == null) return NotFound();
            else
            {
                if (amount > 0 && curraccount.Balance >= amount && amount<=0) 
                {
                    // خصم المبلغ من الرصيد
                    curraccount.Balance -= amount;

                    // إضافة الحركة مع التاريخ مباشرة في قاعدة البيانات
                    var withdraw = new withdraw
                    {
                        Amount = -amount, // سالب للمبلغ في حالة السحب
                        Date = DateTime.Now, // التاريخ

                    };


                    _withdraw.CreateAsync(withdraw);
                    _withdraw.SaveChangesasync();
                    _account.update(curraccount);
                    _account.SaveChangesasync();



                    return RedirectToAction(nameof(DisplayMovements));
                }
                else
                {
                    return BadRequest("insufficient fund");
                }
            }

        }
            
            public ActionResult loan()
        {
            return View();
        }
        [HttpPost]
         public async Task<ActionResult> Loan(decimal amount, int ?accountid)
        {
            if (!accountid.HasValue) return BadRequest();

            var account = await  _account.getaccountbyid(accountid.Value);
            if (account == null) return NotFound();
            else
            {
                if (amount > 0 )
                {
                    // إضافة القرض إلى الرصيد
                    account.Balance += amount;

                    // إضافة الحركة للقرض مع التاريخ
                    var loan = new Loan
                    {
                        LoanAmount = amount,
                        Date = DateTime.Now

                    };
                    _loan.CreateAsync(loan);
                    _loan.SaveChangesasync();
                    _account.update(account);
                    _account.SaveChangesasync();

                    return RedirectToAction("DisplayMovements");

                }
                return BadRequest("insufficient fund");
            }
          

        }

        public ActionResult Transfer()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Transfer(decimal amount, int toaccountid, int fromaccountid)
        {
           
            var toaccount = await _account.getaccountbyid(toaccountid);
            var fromaccount = await _account.getaccountbyid(fromaccountid);

            if (amount > 0 && fromaccount.Balance >= amount && toaccount != null)
            {
                // خصم المبلغ من الحساب المرسل
                fromaccount.Balance -= amount;
                toaccount.Balance += amount;

                // إضافة الحركات مع التاريخ مباشرة في قاعدة البيانات
                var transferfrom = new Transfer
                {
                    Amount = -amount,
                    TransferDatefrom = DateTime.Now,
                    type= "from"

                };
                _account.update(fromaccount);
                _account.SaveChangesasync();
                var transferto = new Transfer
                {
                    Amount = amount,
                    TransferDateto = DateTime.Now,
                    type= "to"

                };
                _account.update(toaccount);
                _account.SaveChangesasync();
                _transfer.CreateAsync(transferto);
                _transfer.CreateAsync(transferfrom);

                _transfer.SaveChangesasync();

                return RedirectToAction("DisplayMovements");
            }
            else
            {
                return NotFound();
            }
        }
      
            // متغير للتحكم في ترتيب الحركات
            private bool isSorted = false;

        [HttpGet ]
            public async Task< ActionResult> DisplayMovements(int accountid)
            {
            // الحصول على بيانات الحساب (استبدل هذا الجزء بالحصول الفعلي من الـ Database)
            var account = _account.getaccountbyid(accountid);
            var loans =await _loan.GetLoansByAccountIdAsync(accountid);
            var transfers = await _transfer.GetTransactionsByAccountIdAsync(accountid);
            var withdraws = await _withdraw.GetWithdrawsAsync(accountid);
            var model = new displaymovementviewmodel()
            {
                Transfers= transfers.ToList(),
                Loans = loans.ToList(),
                withdraws = withdraws.ToList()
            };
                if (isSorted)
                {
                model.Loans.OrderBy(l => l.Date);
                model.Transfers.OrderBy(t => t.TransferDateto);
                model.withdraws.OrderBy(t => t.Date);
                }

            // إرسال البيانات إلى الفيو
            return View(model);
            }

           public ActionResult Sort()
        {
            return View();
        } 
            [HttpPost, ActionName("Sort")]
            public ActionResult toggleSort()
            {
                // تغيير حالة الترتيب
                isSorted = !isSorted;

                // إعادة تحميل الحركات مع الترتيب الجديد
                return RedirectToAction(nameof(DisplayMovements));
            }
            public ActionResult displaybalance()
        {
            return View();  
        }
        [HttpGet]
        public async Task<ActionResult> displaybalance(int accountid)
        {
            var account =  await _account.getaccountbyid(accountid);
            var balance = new Account
            {
                Balance = account.Balance
            };
            return View(balance);

        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {

            if (!id.HasValue) { return BadRequest(); }
            var account = await _account.getaccountbyid(id.Value);
            if (account is null) { return NotFound(); }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        _account.Delete(account);
                        return RedirectToAction(nameof(DisplayMovements));

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }

                return View(account);
            }

        }


    }
}


