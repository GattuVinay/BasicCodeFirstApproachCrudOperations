using BasicCodeFirstApproachCrudOperations.DbContextServices;
using BasicCodeFirstApproachCrudOperations.Interface;
using BasicCodeFirstApproachCrudOperations.Models.Employe;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;

namespace BasicCodeFirstApproachCrudOperations.Repository
{
    public class DemoControllerRepository : IEmployee
    { 

        private readonly EmpDataContext _empDataContext;

        public DemoControllerRepository(EmpDataContext empDataContext)
        {
            _empDataContext = empDataContext;
        }
        public List<Employee> EmpDetails()
        {
            return _empDataContext.Employees.ToList();

        }

        
    }
}
