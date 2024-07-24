using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Models.ProductModels;
using GeneralStoreMVC.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace GeneralStoreMVC.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductIndex> products = await _productService.GetAllProductAsync();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }

            await _productService.CreateNewProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [ActionName("Details")]
        public async Task<IActionResult> ProductDetails(int id)
        {
            if (!ModelState.IsValid)
                return View();

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return RedirectToAction(nameof(Index));

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View();

            var product = await _productService.GetProductByIdForEditAsync(id);

            if (product == null)
                return RedirectToAction(nameof(Index));

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var product = await _productService.EditProductInfoAsync(model);

            if (!product)
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

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return RedirectToAction(nameof(Index));

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDetail model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            await _productService.DeleteProductAsync(model.Id);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}