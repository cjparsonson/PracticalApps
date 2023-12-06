using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;

namespace Northwind.Web.Pages;

public class CustomerOrdersModel : PageModel
{
    public Customer? Customer { get; set; }
    private NorthwindContext _db;
    public CustomerOrdersModel(NorthwindContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        string? id = HttpContext.Request.Query["id"];
        Customer = _db.Customers.Include(c => c.Orders)
            .SingleOrDefault(c => c.CustomerId == id);
    }
}
