
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
