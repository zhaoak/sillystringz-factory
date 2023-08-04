using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
      private readonly FactoryContext _db;

      public EngineersController(FactoryContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Engineer> model = _db.Engineers.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Engineer engie)
      {
        if (ModelState.IsValid == false)
        {
          // if not valid, redirect to create page 
          return View(engie);
        }
        else
        {
          // if valid
          _db.Engineers.Add(engie);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }

      public ActionResult Details(int id)
      {
        Engineer thisEngie= _db.Engineers
                            .Include(engie => engie.JoinEntities)
                            .ThenInclude(join => join.Machine)
                            .FirstOrDefault(engie => engie.EngineerId == id);
        return View(thisEngie);
      }

      public ActionResult Edit(int id)
      {
      Engineer engie = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      return View(engie);
      }

      [HttpPost]
      public ActionResult Edit(Engineer engie)
      {
        if (ModelState.IsValid == false)
        {
          // if not valid, redirect to create page 
          return View(engie);
        }
        else
        {
          // if valid
          _db.Engineers.Update(engie);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }

      public ActionResult Delete(int id)
      {
        Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        return View(thisEngineer);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        _db.Engineers.Remove(thisEngineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}
