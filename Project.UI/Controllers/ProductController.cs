using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IServices;
using X.PagedList;

namespace Project.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IMemoryCache _memoryCache;

        public ProductController(ILogger<ProductController> logger, IProductService productService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _productService = productService;
            _memoryCache = memoryCache;
        }

        // GET: ProductController
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                int pageSize = 4;
                int pageNumber = (page ?? 1);

                //Get peginated data
                var products = await _productService.GetPaginatedProducts(pageNumber, pageSize);

                // Convert the list of products to an instance of StaticPagedList<ProductViewModel>>
                var pagedProducts = new StaticPagedList<ProductViewModel>(products.Data, pageNumber, pageSize, products.TotalCount);

                return View(pagedProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products");
                return StatusCode(500, ex.Message);
            }

        }

        //GET: ProductController
        public async Task<IActionResult> IndexWithoutPagination()
        {
            try
            {
                var products = await _productService.GetProducts();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products");
                return StatusCode(500, ex.Message);
            }

        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = new ProductViewModel();

                // Attempt to retrieve the product from the cache
                if (_memoryCache.TryGetValue($"Product_{id}", out ProductViewModel cachedProduct))
                {
                    product = cachedProduct;
                }
                else
                {
                    // If not found in cache, fetch the product from the data source
                    product = await _productService.GetProduct(id);

                    if (product != null)
                    {
                        // Cache the product with an expiration time of 10 minutes
                        _memoryCache.Set($"Product_{id}", product, TimeSpan.FromMinutes(10));
                    }
                }

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.IsExists("Name", model.Name))
                {
                    ModelState.AddModelError("Exists", $"The product name- '{model.Name}' already exists");
                    return View(model);
                }

                if (await _productService.IsExists("Code", model.Code))
                {
                    ModelState.AddModelError("Exists", $"The product code- '{model.Code}' already exists");
                    return View(model);
                }

                try
                {
                    var data = await _productService.Create(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the product");
                    ModelState.AddModelError("Error", $"An error occurred while adding the product- " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = new ProductViewModel();

                // Attempt to retrieve the product from the cache
                if (_memoryCache.TryGetValue($"Product_{id}", out ProductViewModel cachedProduct))
                {
                    product = cachedProduct;
                }
                else
                {
                    // If not found in cache, fetch the product from the data source
                    product = await _productService.GetProduct(id);

                    if (product != null)
                    {
                        // Cache the product with an expiration time of 10 minutes
                        _memoryCache.Set($"Product_{id}", product, TimeSpan.FromMinutes(10));
                    }
                }
                
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product");
                return StatusCode(500, ex.Message);
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.IsExistsForUpdate(model.Id, "Name", model.Name))
                {
                    ModelState.AddModelError("Exists", $"The product name- '{model.Name}' already exists");
                    return View(model);
                }

                if (await _productService.IsExistsForUpdate(model.Id, "Code", model.Code))
                {
                    ModelState.AddModelError("Exists", $"The product code- '{model.Code}' already exists");
                    return View(model);
                }

                try
                {
                    await _productService.Update(model);

                    // Remove data from cache by key
                    _memoryCache.Remove($"Product_{model.Id}");
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while updating the product");
                    ModelState.AddModelError("Error", $"An error occurred while updating the product- " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // Get: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);

                // Remove data from cache by key
                _memoryCache.Remove($"Product_{id}");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product");
                return View("Error");
            }
        }
    }
}
