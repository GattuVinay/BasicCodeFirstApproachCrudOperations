using BasicCodeFirstApproachCrudOperations.DbContextServices;
using BasicCodeFirstApproachCrudOperations.Migrations;
using BasicCodeFirstApproachCrudOperations.Models.Employe;
using Microsoft.AspNetCore.Mvc;
using BasicCodeFirstApproachCrudOperations.Repository;
using BasicCodeFirstApproachCrudOperations.Interface;
using PDFGeneratrorPackageLibrary;

namespace BasicCodeFirstApproachCrudOperations
{
    public class DemoController : Controller 
    {
       private readonly DemoControllerRepository _demoControllerRepository;
        private readonly EmpDataContext _empDataContext;
        readonly IEmployee _employee;

        public DemoController(EmpDataContext empDataContext, DemoControllerRepository demoControllerRepository,IEmployee employee)
        {
            _empDataContext = empDataContext;
            _demoControllerRepository = demoControllerRepository;
            _employee = employee;
        }
        // GET: Demo  
        public ActionResult  EmpDetails()
        {
            return View(_demoControllerRepository.EmpDetails());
            // return View(_empDataContext.Employees.ToList());
        }

        public ActionResult Create()
        { 
           return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _empDataContext.Employees.Add(employee);
                _empDataContext.SaveChanges(true);
                return RedirectToAction("EmpDetails", "Demo");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }
        
        public ActionResult Edit(string id)
        {

            int empId = Convert.ToInt32(id);
            var emp = _empDataContext.Employees.Find(empId);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee objEmp)
        {
            var data = _empDataContext.Employees.Find(objEmp.EmpId);
            if (data != null)
            {
                data.Name = objEmp.Name;
                data.Address = objEmp.Address;
                data.Email = objEmp.Email;
                data.MobileNo = objEmp.MobileNo;
            }
            _empDataContext.SaveChanges(true);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = _empDataContext.Employees.Find(empId);
            return View(emp);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult Delete(Employee objEmp)
        {
            var emp = _empDataContext.Employees.Find(objEmp.EmpId);

                if (emp != null)
                    _empDataContext.Remove(emp);
                _empDataContext.SaveChanges(true);
                return RedirectToAction("EmpDetails");
            
        }

        public ActionResult Details(int id)
        {
            int empId = Convert.ToInt32(id);
            var emp = _empDataContext.Employees.Find(empId);
            return View(emp);

        }

        public ActionResult pdfDownload(int id)
        {
            int empId = Convert.ToInt32(id);
            var emp = _empDataContext.Employees.Find(empId);


            string? htmlContent = Razor.Templating.Core.RazorTemplateEngine.RenderAsync("Demo/pdfDownload", emp).Result;
            var pdfBytes = PDFGenerator.GeneratePDF(htmlContent);
            return File(pdfBytes, "application/pdf", "filename.pdf");

        }
    }

}
