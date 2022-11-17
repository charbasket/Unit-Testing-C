using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _storage;
        // We need to refactor -> EmployeeStorage
        // private EmployeeContext _db;

        public EmployeeController(IEmployeeStorage storage = null)
        {
            _storage = storage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            // We need to refactor -> EmployeeStorage
            // var employee = _db.Employees.Find(id);
            // _db.Employees.Remove(employee);
            // _db.SaveChanges();

            _storage.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult
    {
    }

    public class RedirectResult : ActionResult
    {
    }

    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}