using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMart.AdminService.Models;
using EMart.AdminService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMart.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _admrepo;

        public AdminController(IAdminRepository admrepo)
        {
            _admrepo = admrepo;
        }

        [HttpPost]
        [Route("AddCategories")]
        public IActionResult Add(Category catobj)
        {
            try
            {
                _admrepo.AddCategories(catobj);
                return Ok();
            }

            catch(Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("AddSubCategories")]
        public IActionResult AddSub(SubCategory scobj)
        {
            try
            {
                _admrepo.AddSubCategories(scobj);
                return Ok();
            }

            catch(Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_admrepo.GetCategories());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("ViewCategories")]
        public IActionResult ViewCategories()
        {
            try
            {

                return Ok(_admrepo.ViewCategories());
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("ViewSubCategories")]
        public IActionResult ViewSubCategories()
        {
            try
            {

                return Ok(_admrepo.ViewSubCategories());
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }


        [HttpPut]
        [Route("EditCategories")]
        public IActionResult EditCategories(Category catobj)
        {
            try
            {
                _admrepo.EditCategories(catobj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }


        [HttpPut]
        [Route("EditSubCategories")]
        public IActionResult EditSubCategories(SubCategory subcatobj)
        {
            try
            {
                _admrepo.EditSubCategories(subcatobj);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCategories/{catid}")]
        public IActionResult DeleteCategories(string catid)
        {
            try
            {
                _admrepo.DeleteCategories(catid);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteSubCategories/{subcatid}")]
        public IActionResult DeleteSubCategories(string subcatid)
        {
            try
            {
                _admrepo.DeleteSubCategories(subcatid);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("GetSubCatById/{subcatid}")]
        public IActionResult GetSubCatById(string subcatid)
        {
            try
            {

                return Ok(_admrepo.GetSubCatById(subcatid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetCatById/{catid}")]
        public IActionResult GetCatById(string catid)
        {
            try
            {

                return Ok(_admrepo.GetCatById(catid));
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

    }
}

