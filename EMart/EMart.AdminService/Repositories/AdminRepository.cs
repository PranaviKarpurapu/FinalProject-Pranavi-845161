using EMart.AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMart.AdminService.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EMartDBContext _context;

        public AdminRepository(EMartDBContext context)
        {
            _context = context;
        }
        public void AddCategories(Category catobj)
        {
            _context.Add(catobj);
            _context.SaveChanges();
        }

        public void AddSubCategories(SubCategory scobj)
        {
            _context.Add(scobj);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Category.ToList();
        }
       public List<Category> ViewCategories()
        {
            return _context.Category.ToList();
        }
        public List<SubCategory> ViewSubCategories()
        {
            return _context.SubCategory.ToList();
        }
        public void EditCategories(Category catobj)
        {
            _context.Category.Update(catobj);
            _context.SaveChanges();
        }
        public void EditSubCategories(SubCategory subcatobj)
        {
            _context.SubCategory.Update(subcatobj);
            _context.SaveChanges();
        }
        public void DeleteCategories(string catid)
        {
         Category catobj=_context.Category.Find(catid);
            _context.Remove(catobj);
            _context.SaveChanges();
        }
        public void DeleteSubCategories(string subcatid)

        {
          SubCategory subcatobj=_context.SubCategory.Find(subcatid);
            _context.Remove(subcatobj);
            _context.SaveChanges();
        }
        public Category GetCatById(string catid)
        {
            return _context.Category.Find(catid);

        }

        public SubCategory GetSubCatById(string subcatid)
        {
            return _context.SubCategory.Find(subcatid);

        }


    }
}