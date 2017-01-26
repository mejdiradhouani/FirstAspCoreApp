using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudCore.Controllers
{
    public class PetController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {   
            return View(DAL.Pets_DAL.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pet_Model p)
        {
            DAL.Pets_DAL.Create(p);
            return RedirectToAction("Index", "Pet");
        }
        public IActionResult Delete(int id)
        {
            if (!id.Equals(null))
            {
                DAL.Pets_DAL.Delete(id);
            }
            return RedirectToAction("Index", "Pet");
        }
        public IActionResult Update(int id)
        {
            
            return View(DAL.Pets_DAL.GetPetById(id));
        }
        [HttpPost]
        public IActionResult Update(Pet_Model p)
        {
            if(p!=null)
            {
                DAL.Pets_DAL.Update(p);
            }
            return RedirectToAction("Index", "Pet");
        }
    }
}
