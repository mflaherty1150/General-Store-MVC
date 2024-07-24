using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Models.CustomerModels;
using GeneralStoreMVC.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeneralStoreMVC.Mvc.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger,
            ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        List<CustomerIndex> customers = await _customerService.GetAllCustomersAsync();

        return View(customers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerCreate model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is Invalid";
            return View(model);
        }

        await _customerService.CreateNewCustomerAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [ActionName("Details")]
    public async Task<IActionResult> CustomerDetails(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
            return RedirectToAction(nameof(Index));

        return View(customer);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var customer = await _customerService.GetCustomerByIdForEditAsync(id);

        if (customer == null)
            return RedirectToAction(nameof(Index));

        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CustomerEdit model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        var customer = await _customerService.EditCustomerInfoAsync(model);

        if (!customer)
        {
            ViewData["ErrorMsg"] = "Unable to save to the Databas. Please try agian.";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("Details", new { id = model.Id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
            return RedirectToAction(nameof(Index));

        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CustomerDetail model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _customerService.DeleteCustomerAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}