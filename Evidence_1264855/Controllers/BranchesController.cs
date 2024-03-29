﻿using Evidence_1264855.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence_1264855.Controllers
{
    public class BranchesController : Controller
    {
        //Database Injection Dependency/ db Context
        readonly CompanyDbContext db = null;
        public BranchesController(CompanyDbContext db) { this.db = db; }

        //Index Action
        public IActionResult Index()
        {
            return View(db.Branches.ToList());
        }
        //Create Action
        public IActionResult Create()
        {
            return View();
        }
        //Create Post Action
        [HttpPost]
        public IActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return PartialView("_MessegeCreatePartial", true);
            }
            return PartialView("_MessegeCreatePartial", false);
        }
        //Update Action
        public IActionResult Update(int id)
        {
            return View(db.Branches.First(b => b.BranchId == id));
        }
        //Update Post Action
        [HttpPost]
        public IActionResult Update(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_MessegeUpdatePartial", true);
            }
            return PartialView("_MessegeUpdatePartial", false);
        }
        //Delete Action
        public IActionResult Delete(int id)
        {
            return View(db.Branches.First(b => b.BranchId == id));
        }
        //Delete Post Action
        [HttpPost, ActionName("Delete")]
        public IActionResult DoDelete(int id)
        {
            Branch branch = new Branch { BranchId = id };
            if (!db.Employees.Any(e => e.BranchId == id))
            {
                db.Entry(branch).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return PartialView("_MessegeDeletePartial", true);
            }
            //ModelState.AddModelError("", "You Cann't Delete the Project because it relatated to Employees.");
            //return View(db.Branches.First(b => b.BranchId == Id));
            return PartialView("_MessegeDeletePartial", false);
        }
    }
}
