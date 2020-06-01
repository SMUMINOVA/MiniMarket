using System;
using System.Linq;
using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class AdminController : Controller
    {
        public DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product p)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            p.CategoryId = int.Parse(Request.Form["CategoryId"]);
            _context.Add(p);
            _context.SaveChanges();
            var product = _context.Products.Where(x => x.Name == p.Name && x.Cost == p.Cost && x.CategoryId == p.CategoryId).SingleOrDefault();
            var cat = _context.Categories.Find(p.CategoryId);
            cat.Products.Add(product);
            _context.SaveChanges();
            cat = _context.Categories.Where(x => x.Id == 1).Single();
            cat.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        [HttpGet]
        public IActionResult Change(){
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Change(Product p){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var product = _context.Products.Find(p.Id);
            if (product == null)
                return NotFound();
            Category neCat;
            Category oldCat;
            if(p.CategoryId != product.CategoryId){
                neCat = _context.Categories.Find(p.CategoryId);
                oldCat = _context.Categories.Find(product.CategoryId);
                oldCat.Products.Remove(product);
                neCat.Products.Add(p);
            }
            product.Name = p.Name;
            product.Cost = p.Cost;
            product.CategoryId = p.CategoryId;
            product.Category = _context.Categories.Find(product.CategoryId);
            if (_context.SaveChanges() < 0)
                return BadRequest();
            return RedirectToAction("Categories");
        }
        [HttpGet]
        public IActionResult Delete(){
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Product p){            
            var product = _context.Products.Find(p.Id);
            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            if (_context.SaveChanges() < 0)
                return BadRequest();     
            return RedirectToAction("Categories");
        }
        [HttpGet]
        public IActionResult Categories(){
            var p = _context.Products.ToList();
            ViewBag.Categories = _context.Categories.ToList();            
            return View(p);
        }        
        [HttpPost]
        public IActionResult Categories(int Id){
            var p = _context.Products.Where(x => x.CategoryId == Id).Select(x=>x).ToList();
            ViewBag.Categories = _context.Categories.ToList();            
            return View(p);
        }
    }
}
