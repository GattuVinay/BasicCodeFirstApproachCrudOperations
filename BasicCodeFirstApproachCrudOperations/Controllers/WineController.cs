using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using BasicCodeFirstApproachCrudOperations.Models.Wine;
using BasicCodeFirstApproachCrudOperations.DbContextServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BasicCodeFirstApproachCrudOperations.Controllers
{
    public class WineController : Controller
    {
        private readonly EmpDataContext _empDataContext;

        public WineController(EmpDataContext empDataContext)
        {
            _empDataContext = empDataContext;
        }
        public ActionResult Wine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Wines(int id)
        {
            var data = _empDataContext.Wines.Select(a => id).ToList();

            return PartialView(data);
        }

        public ActionResult Beers()
        {

            try
            {
                var allBeers = _empDataContext.Beer.ToList();
                return View(allBeers);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return View();
            }
                        
        }

        

        //    public static MonthlyBillingHeaderViewModel GetMonthlyBillingHeaderById(RBADBContext context, int id)
        //    {
        //        MonthlyBillingHeaderViewModel billingHeader = (from h in context.MonthlyBillingHeader
        //                                                       join mbs in context.MonthlyBillingStatus on h.MonthlyBillingStatusID equals mbs.ID
        //                                                       where h.ID == id
        //                                                       select new MonthlyBillingHeaderViewModel
        //                                                       {
        //                                                           ID = h.ID,
        //                                                           MonthlyBillingStatusID = h.MonthlyBillingStatusID,
        //                                                           BillingMonthYear = h.BillingMonthYear,
        //                                                           Status = mbs.Name,
        //                                                           LastGenerated = h.LastGenerated != DateTime.MinValue ? h.LastGenerated.ToString("MM/dd/yyyy hh:mm tt") : String.Empty,
        //                                                           ApprovedOn = h.ApprovedOn != DateTime.MinValue ? h.ApprovedOn.ToString("MM/dd/yyyy hh:mm tt") : String.Empty
        //                                                       }).FirstOrDefault();
        //        if (billingHeader != null)
        //}
    }
}
