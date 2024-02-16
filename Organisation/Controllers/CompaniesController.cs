using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organisation.Data;
using Organisation.Models;
using Organisation.Models.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Organisation.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyDbContext dbContext;
        public CompaniesController(CompanyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CompanyViewModel viewModel)
        {
            var company = new Company
            {
                Name = viewModel.Name,
                Department = viewModel.Department,
                Establish = viewModel.Establish,
                Address = viewModel.Address,

            };
            await dbContext.Companies.AddAsync(company);
            await dbContext.SaveChangesAsync();


            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var company = await dbContext.Companies.ToListAsync();
            return View(company);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var company = await dbContext.Companies.FindAsync(Id);
            return View(company);
        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(Company viewModel)
        {
          var company = await dbContext.Companies.FindAsync(viewModel.Id);
            if(company is not null)
            {
                company.Name = viewModel.Name;
                company.Department = viewModel.Department;
                company.Establish = viewModel.Establish;
                company.Address = viewModel.Address;

               
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Companies");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Company viewModel)
        {
            var company = await dbContext.Companies.AsNoTracking().SingleOrDefaultAsync(x=>x.Id== viewModel.Id);
            if(company is not null) 
            {
                dbContext.Companies.Remove(company);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Companies");
        }
        
    }
}
