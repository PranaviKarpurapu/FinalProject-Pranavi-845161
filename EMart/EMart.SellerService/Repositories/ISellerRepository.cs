using EMart.SellerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMart.SellerService.Repositories
{
    public interface ISellerRepository
    {

        void EditProfile(Seller sobj);

        Seller ViewProfile(string sid);
    }
}
