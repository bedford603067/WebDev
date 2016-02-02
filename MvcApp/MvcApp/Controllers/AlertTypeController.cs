using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;

namespace MvcApp
{
    public class AlertTypeController : Controller
    {
        private IEnumerable<Models.AlertType> GetAlertTypes()
        {
            string connection = "mongodb://localhost:27017"; ;
            IEnumerable<Models.AlertType> list = new DAL.AlertingRepository(connection).GetAlertTypes();
            return list;
        }

        // GET: AlertType
        public ActionResult Index()
        {
            IEnumerable<Models.AlertType> list = GetAlertTypes();
            return View(list);
        }

        public async Task<ActionResult> IndexAsync()
        {
            ViewBag.SyncOrAsync = "Asynchronous";

            string connection = "mongodb://localhost:27017"; ;
            var repository = new DAL.AlertingRepository(connection);
            return View("Index", await repository.GetAlertTypesAsync());
        }

        // GET: AlertType/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Models.AlertType> list = GetAlertTypes();
            return View(list.ToList().Find(p => p.Id == id));
        }

        // GET: AlertType/Create
        public ActionResult Create()
        {
            return View(new Models.AlertType());
        }

        // POST: AlertType/Create
        [HttpPost]
        public ActionResult Create(Models.AlertType model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlertType/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Models.AlertType> list = GetAlertTypes();
            return View(list.ToList().Find(p => p.Id == id));
        }

        // POST: AlertType/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.AlertType model)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlertType/Delete/5
        public ActionResult Delete(int id)
        {
            IEnumerable<Models.AlertType> list = GetAlertTypes();
            return View(list.ToList().Find(p => p.Id == id));
        }

        // POST: AlertType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
