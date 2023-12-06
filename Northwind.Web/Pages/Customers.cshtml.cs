using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.EntityModels;

namespace Northwind.Web.Pages
{
    public class CustomersModel : PageModel
    {
        private NorthwindContext _db;
        public CustomersModel(NorthwindContext db)
        {
            _db = db;
        }
        public ILookup<string?, Customer>? CustomersByCountry { get; set; }
        public void OnGet()
        {            
            CustomersByCountry = _db.Customers
                .OrderBy(c => c.Country)
                .ToLookup(c => c.Country);
        }
    }
}
