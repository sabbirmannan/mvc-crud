using FluentValidation.Results;
using MVC_CRUD.Models;
using MVC_CRUD.Repository;
using MVC_CRUD.Validation;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }

        public ActionResult Index()
        {
            var emp = _employeeRepository.GetAll();
            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            EmployeeValidation val = new EmployeeValidation();
            ValidationResult model = val.Validate(obj);
            if (model.IsValid)
            {
                _employeeRepository.Add(obj);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in model.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(obj);
        }

        public ActionResult Update(int id)
        {
            var emp = _employeeRepository.FindBy(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(emp);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public ActionResult Delete(int id)
        {
            var emp = _employeeRepository.FindBy(id);
            return View(emp);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}