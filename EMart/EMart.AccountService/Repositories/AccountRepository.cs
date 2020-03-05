using EMart.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMart.AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly EMartDBContext _context;
        public AccountRepository(EMartDBContext context)
        {
            _context = context;
        }


        public Buyer BuyerLogin(string uname, string pwd)
        {
            Buyer b = _context.Buyer.SingleOrDefault(res => res.UserName == uname && res.Password == pwd);
            return b;
        }

        public void BuyerRegister(Buyer buyerobj)
        {
            _context.Add(buyerobj);
            _context.SaveChanges();
        }

        public Seller SellerLogin(string uname, string pwd)
        {
            Seller s = _context.Seller.SingleOrDefault(res => res.UserName == uname && res.Password == pwd);
            return s;
        }

        public void SellerRegister(Seller sellerobj)
        {
            _context.Add(sellerobj);
            _context.SaveChanges();
        }
    }

        
    }

