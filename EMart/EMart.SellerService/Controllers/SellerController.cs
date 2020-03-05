using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMart.SellerService.Models;
using EMart.SellerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMart.SellerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _srepo;

        public SellerController(ISellerRepository srepo)
        {
            _srepo = srepo;
        }

        [HttpPut]
        [Route("EditProfile")]
        public IActionResult EditProfile(Seller sobj)
        {
            try
            {

                _srepo.EditProfile(sobj);
                return Ok();
            }
            
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Route("ViewProfile/{sid}")]
        public IActionResult ViewProfile(string sid)
        {
            try
            {
                
                return Ok(_srepo.ViewProfile(sid));
            }

            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}