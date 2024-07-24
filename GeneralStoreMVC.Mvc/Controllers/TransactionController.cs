using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Models.TransactionModels;
using GeneralStoreMVC.Services.TransactionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeneralStoreMVC.Mvc.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<IActionResult> Index()
    {
        List<TransactionIndex> transactions = await _transactionService.GetAllTransactionAsync();

        return View(transactions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TransactionCreate model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMsg"] = "Model State is Invalid";
            return View(model);
        }

        await _transactionService.CreateNewTransactionAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [ActionName("Details")]
    public async Task<IActionResult> TransactionDetails(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var transaction = await _transactionService.GetTransactionByIdAsync(id);

        if (transaction == null)
            return RedirectToAction(nameof(Index));

        return View(transaction);
    }

    [ActionName("CustomerTransactionDetails")]
    public async Task<IActionResult> CustomerDetails(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var transaction = await _transactionService.GetAllTransactionsForCustomerAsync(id);

        if (transaction == null)
            return RedirectToAction(nameof(Index));

        return View(transaction);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var transaction = await _transactionService.GetTransactionByIdForEditAsync(id);

        if (transaction == null)
            return RedirectToAction(nameof(Index));

        return View(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TransactionEdit model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        var transaction = await _transactionService.EditTransactionInfoAsync(model);

        if (!transaction)
        {
            ViewData["ErrorMsg"] = "Unable to save to the Database. Please try agian.";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("Details", new { id = model.Id });
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var transaction = await _transactionService.GetTransactionByIdAsync(id);

        if (transaction == null)
            return RedirectToAction(nameof(Index));

        return View(transaction);
    }

    // POST: Transaction/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(TransactionDetail model)
    {
        if (!ModelState.IsValid)
        {
            return View(ModelState);
        }

        await _transactionService.DeleteTransactionAsync(model.Id);

        return RedirectToAction(nameof(Index));
    }
}
