using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApplication.Data;
using TrainingApplication.Models;

namespace TrainingApplication.Controllers
{
    public class CharacterListController : Controller
    {
        private readonly AppDbContext _db;
       

        public CharacterListController(AppDbContext db)
        {
            _db = db;
        }

        //SEARCH Filtering
        public IActionResult Index(string searchBy, string search)
        {
            IEnumerable<Character> objList = _db.Characters;
            if (searchBy == "Name"){
                return View(_db.Characters.Where(x => x.Characters.StartsWith(search) || search == null).ToList());
            }else if(searchBy == "Nation"){
                return View(_db.Characters.Where(x => x.Nation == search || search == null).ToList());
            }else if(searchBy == "Vision"){
                return View(_db.Characters.Where(x => x.VisionType == search || search == null).ToList());
            }else if(searchBy == "Weapon"){
                return View(_db.Characters.Where(x => x.Weapon == search || search == null).ToList());
            }
            else
            {
                return View(objList);
            }
        }


        //Get-Create
        public IActionResult CreateCharacter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST-Create
        public IActionResult CreateCharacter(Character obj)
        {
            if (ModelState.IsValid)
            {
                _db.Characters.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET-Delete
        public IActionResult Remove(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Characters.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST-Delete
        public IActionResult RemovePost(int? id)
        {
            var obj = _db.Characters.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Characters.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Characters.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST-Update
        public IActionResult Update(Character obj)
        {
            if (ModelState.IsValid)
            {
                _db.Characters.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
