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
        public IActionResult Index()
        {
            IEnumerable<Character> objList = _db.Characters;
            return View(objList);
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
