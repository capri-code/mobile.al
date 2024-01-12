using Microsoft.AspNetCore.Mvc;

namespace mobile.al.Controllers
{
    public class VehiclesController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        public VehiclesController(IProductsService productsService,
            ICategoriesService categoriesService
            )2
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            Task.Run(StaticIncrementor.IncrementBy1);
            return View(await _productsService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoriesService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await _productsService.AddProduct(new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                });
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await _categoriesService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _productsService.GetById(id);
            if (product is null)
                return RedirectToAction(nameof(Index));

            return View(new ProductAddRequestModel
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductAddRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productsService.GetById(id);
                if (product == null)
                    return RedirectToAction(nameof(Index));
                product.Description = model.Description;
                product.Name = model.Name;
                product.Price = model.Price;
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productsService.GetById(id);
            if (product == null)
                return RedirectToAction(nameof(Index));
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var product = await _productsService.GetById(id);
            if (product == null)
                return RedirectToAction(nameof(Index));
            await _productsService.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
