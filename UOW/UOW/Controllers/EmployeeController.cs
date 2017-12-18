using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UOW.Models;

namespace UOW.Controllers
{
    //public class EmployeeController : Controller
    //{
    //    private EmployeeContaxt db = new EmployeeContaxt();

    //    //
    //    // GET: /Employee/

    //    public ActionResult Index()
    //    {
    //        return View(db.Employees.ToList());
    //    }

    //    //
    //    // GET: /Employee/Details/5

    //    public ActionResult Details(int id = 0)
    //    {
    //        Employee employee = db.Employees.Find(id);
    //        if (employee == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(employee);
    //    }

    //    //
    //    // GET: /Employee/Create

    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Employee/Create

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(Employee employee)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Employees.Add(employee);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(employee);
    //    }

    //    //
    //    // GET: /Employee/Edit/5

    //    public ActionResult Edit(int id = 0)
    //    {
    //        Employee employee = db.Employees.Find(id);
    //        if (employee == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(employee);
    //    }

    //    //
    //    // POST: /Employee/Edit/5

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(Employee employee)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(employee).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(employee);
    //    }

    //    //
    //    // GET: /Employee/Delete/5

    //    public ActionResult Delete(int id = 0)
    //    {
    //        Employee employee = db.Employees.Find(id);
    //        if (employee == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(employee);
    //    }

    //    //
    //    // POST: /Employee/Delete/5

    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Employee employee = db.Employees.Find(id);
    //        db.Employees.Remove(employee);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        db.Dispose();
    //        base.Dispose(disposing);
    //    }
    //}

    public class EmployeeController : Controller
    {
        private UnitOfWork uow = null;
        //
        // GET: /Employees/

        public EmployeeController()
        {
            uow = new UnitOfWork();
        }

        public EmployeeController(UnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View(uow.EmployeeRepository.GetAll().ToList());
        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee Employee = uow.EmployeeRepository.Get(c => c.ID == id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employees/Create

        [HttpPost]
        public ActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                uow.EmployeeRepository.Add(Employee);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Employee);
        }

        //
        // GET: /Employees/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employee Employee = uow.EmployeeRepository.Get(c => c.ID == id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                uow.EmployeeRepository.Update(Employee);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        //
        // GET: /Employees/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employee Employee = uow.EmployeeRepository.Get(c => c.ID == id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        //
        // POST: /Employees/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee Employee = uow.EmployeeRepository.Get(c => c.ID == id);
            uow.EmployeeRepository.Delete(Employee);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}