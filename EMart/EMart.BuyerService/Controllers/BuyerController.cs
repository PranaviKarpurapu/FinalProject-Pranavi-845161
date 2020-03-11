using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMart.BuyerService.Models;
using EMart.BuyerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMart.BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepository _brepo;

        public BuyerController(IBuyerRepository brepo)
        {
            _brepo = brepo;
        }

        [HttpGet]
        [Route("SearchItems/{name}")]
        public IActionResult SearchItems(string name)
        {
            try
            {
                return Ok(_brepo.SearchItems(name));
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("BuyItem")]

        public IActionResult BuyItem(TransactionHistory item)
        {
            try
            {
                _brepo.BuyItem(item);
                return Ok();
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
             }
        }

        [HttpPut]
        [Route("EditProfile")]
        
        public IActionResult EditProfile(Buyer bobj)
        {
            try
            {
                _brepo.EditProfile(bobj);
                return Ok();
            }

            catch(Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("ViewProfile/{bid}")]

        public IActionResult ViewProfile(string bid)
        {
            try
            {
                return Ok(_brepo.ViewProfile(bid));
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("TransactionHistory/{bid}")]

        public IActionResult TransactionHistory(string bid)
        {
            try
            {
                return Ok(_brepo.TransactionHistory(bid));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetCategories")]

        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_brepo.GetCategories());
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("SubCategories/{catid}")]

        public IActionResult GetSubCategories(string catid)
        {
            try
            {
                return Ok(_brepo.GetSubCategories(catid));
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [Route("Addtocart")]

        public IActionResult Addtocart(Cart cartobj)
        {
            try
            {
                _brepo.Addtocart(cartobj);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpDelete]
        [Route("Deletefromcart/{cartid}")]
        public IActionResult Deletefromcart(string cartid)
        {
            try
            {
                _brepo.Deletefromcart(cartid);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("ViewCart/{bid}")]
        public IActionResult ViewCart(string bid)
        {
            try
            {

                return Ok(_brepo.ViewCart(bid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }


        //[HttpGet]
        //[Route("PurchaseHistory/{bid}")]
        //public IActionResult PurchaseHistory(string bid)
        //{
        //    try
        //    {

        //        return Ok(_brepo.PurchaseHistory(bid));
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.InnerException.Message);
        //    }
        //}
    }
}
