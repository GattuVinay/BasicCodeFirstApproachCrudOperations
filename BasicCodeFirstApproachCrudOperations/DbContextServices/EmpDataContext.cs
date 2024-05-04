using BasicCodeFirstApproachCrudOperations.Models.Employe;
using BasicCodeFirstApproachCrudOperations.Models.Wine;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BasicCodeFirstApproachCrudOperations.DbContextServices
{
    public class EmpDataContext : IdentityDbContext
    {

        public EmpDataContext(DbContextOptions<EmpDataContext> options): base(options)
        {

            
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<Beer> Beer { get; set; }
    }
}
