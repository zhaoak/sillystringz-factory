using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
      private readonly FactoryContext _db;

      public MachinesController(FactoryContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Machine> model = _db.Machines.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Machine machine)
      {
        if (ModelState.IsValid == false)
        {
          // if not valid, redirect to create page 
          return View(machine);
        }
        else
        {
          // if valid
          _db.Machines.Add(machine);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }

      public ActionResult Details(int id)
      {
        Machine thisMachine = _db.Machines
                            .Include(mech => mech.JoinEntities)
                            .ThenInclude(join => join.Engineer)
                            .FirstOrDefault(mech => mech.MachineId == id);
        return View(thisMachine);
      }

      public ActionResult Edit(int id)
      {
      Machine machine = _db.Machines.FirstOrDefault(mech => mech.MachineId == id);
      return View(machine);
      }

      [HttpPost]
      public ActionResult Edit(Machine machine)
      {
        if (ModelState.IsValid == false)
        {
          // if not valid, redirect to create page 
          return View(machine);
        }
        else
        {
          // if valid
          _db.Machines.Update(machine);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }

      public ActionResult Delete(int id)
      {
        Machine thisMachine = _db.Machines.FirstOrDefault(mech => mech.MachineId == id);
        return View(thisMachine);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        Machine thisMachine = _db.Machines.FirstOrDefault(mech => mech.MachineId == id);
        _db.Machines.Remove(thisMachine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}
