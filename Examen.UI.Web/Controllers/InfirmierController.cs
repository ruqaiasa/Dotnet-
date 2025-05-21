using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.UI.Web.Controllers
{
    public class InfirmierController : Controller
    {
        IPatientService sp;
        IInfirmierService si;
        ILaboratoireService sl;

        public InfirmierController(IInfirmierService si, ILaboratoireService sl,IPatientService sp)
        {
            this.si = si;
            this.sl = sl;
            this.sp = sp;
        }

        // GET: InfirmierController
        public ActionResult Index()
        {
            return View(si.GetMany());
        }

        // GET: InfirmierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfirmierController/Create
        public ActionResult Create()
        {
            ViewBag.liste = new SelectList(sl.GetMany(), "LaboratoireId", "Intitule");


            return View();
        }

        // POST: InfirmierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Infrimier collection )
        {
            try
            {
                si.Add(collection);
                si.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: InfirmierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfirmierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InfirmierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfirmierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
