using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tasks.Context;
using Tasks.Domains;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TaskDbContext _dbContext;
        private readonly UserManager<Customer> _userManager;

        public CustomerController(TaskDbContext dbContext, UserManager<Customer> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _userManager.GetUsersInRoleAsync(nameof(Constants.Constant.CustomerRole));
            var customerViewModels = customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Code = c.Code ?? string.Empty,
                CustomerName = c.Name ?? string.Empty,
                SelectedProductIds = c.Products?.Select(p => p.Product.Id).ToList() ?? new List<int>()
            });

            var viewModel = new CustomerListViewModel { Customers = customerViewModels };
            return View(viewModel);
        }
    }
}
