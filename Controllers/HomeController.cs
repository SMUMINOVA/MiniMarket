using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Market.Models;

namespace Market.Controllers
{
    public class HomeController : Controller
    {
        public DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(){
            return View();
        }
        [HttpGet]
        public IActionResult Products(){
            var p = _context.Products.ToList();
            ViewBag.Categories = _context.Categories.ToList();            
            return View(p);
        }        
        [HttpPost]
        public IActionResult Products(int Id){
            var p = _context.Products.Where(x => x.CategoryId == Id).Select(x=>x).ToList();
            ViewBag.Categories = _context.Categories.ToList();            
            return View(p);
        }
        [HttpGet]
        public IActionResult TrashView(){
            var prod = _context.Trashs.ToList();
            return View();
        }
        [HttpPost("Id")]
        public async Task<IActionResult> AddToTrash(int Id){
            var p = await _context.Products.FindAsync(Id);
            var t = new Trash();
            t.ProductsName = p.Name;
            t.ProductsCost = p.Cost;          
            _context.Trashs.Add(t);
            if(await _context.SaveChangesAsync() > 0){
                return View("GetAdress", t);
            }
            return BadRequest();
        }
        [HttpPost("Id")]
        public async Task<IActionResult> GetAdress(Trash t, int Id){
            var p = _context.Trashs.Find(Id);
            if(await _context.SaveChangesAsync() > 0){
                return RedirectToAction("Trash");
            }
            return BadRequest();
        }
    }
}
