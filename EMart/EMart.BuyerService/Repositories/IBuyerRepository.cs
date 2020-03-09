using EMart.BuyerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMart.BuyerService.Repositories
{
    public interface IBuyerRepository
    {
        List<Items> SearchItems(string name);

        void BuyItem(TransactionHistory item);

        void EditProfile(Buyer bobj);

        Buyer ViewProfile(string bid);

        List<TransactionHistory> TransactionHistory(string bid);

        List<Category> GetCategories();

        List<SubCategory> GetSubCategories(string catid);

        public void Addtocart(Cart cartobj);

       public void Deletefromcart(string cartid);

        List<Cart> ViewCart();
    }
}
