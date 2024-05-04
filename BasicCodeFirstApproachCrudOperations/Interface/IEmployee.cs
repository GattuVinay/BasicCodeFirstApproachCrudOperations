using BasicCodeFirstApproachCrudOperations.Models.Employe;
using Microsoft.AspNetCore.Mvc;

namespace BasicCodeFirstApproachCrudOperations.Interface
{
    public interface IEmployee 
    {
        List<Employee> EmpDetails();
        //List<Employee> Edit();

        //List<T> EmpDetails<T>();
    }
}
